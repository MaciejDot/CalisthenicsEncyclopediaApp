using Microsoft.Extensions.Options;
using RestSharp;
using SimpleCQRS.Command;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Configuration;
using WorkoutExecutionService.DataAccess.Database.Command;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.DTO;
using WorkoutExecutionService.DataAccess.Hangfire;
using WorkoutExecutionService.DataAccessPoint.Cache;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public class PopulateMoodsJob : IPopulateMoodsJob
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly MoodServiceOptions _options;
        private readonly IMoodCacheService _moodCacheService;
        private readonly IRestClient _restClient;
        private readonly IBackgroundJobClientService _backgroundJobClientService;
        public PopulateMoodsJob(
            IQueryProcessor queryProcessor,
            IOptions<MoodServiceOptions> options,
            IMoodCacheService moodCacheService,
            IRestClient restClient,
            ICommandDispatcher commandDispatcher,
            IBackgroundJobClientService backgroundJobClientService
            )
        {
            _moodCacheService = moodCacheService;
            _options = options.Value;
            _queryProcessor = queryProcessor;
            _restClient = restClient;
            _commandDispatcher = commandDispatcher;
            _backgroundJobClientService = backgroundJobClientService;
        }

        public async Task Run()
        {
            try
            {
                var databaseResocure = await _queryProcessor.Process(new GetMoodsQuery(), default);
                var request = new RestRequest(_options.ResocureAddress, Method.GET);
                var response = await _restClient.ExecuteAsync<IEnumerable<MoodDTO>>(request);
                if (!response.IsSuccessful)
                {
                    _moodCacheService.Put(databaseResocure);
                    throw new Exception("Unsuccesful request");
                }
                var serviceResocure = response.Data;
                if (!serviceResocure.OrderBy(x => x.Id).SequenceEqual(databaseResocure.OrderBy(x => x.Id)))
                {
                    _moodCacheService.Put(serviceResocure);
                    if (serviceResocure
                        .Where(x => !databaseResocure.Any(y => y.Id == x.Id && x.Name == y.Name)).Any())
                    {
                        await _commandDispatcher.Dispatch(new AddMoodCommand
                        {
                            Moods =
                        serviceResocure
                            .Where(x => !databaseResocure.Any(y => y.Id == x.Id && x.Name == y.Name))
                        }, default);
                    }

                    if (databaseResocure
                        .Where(x => !serviceResocure.Any(y => y.Id == x.Id)).Any())
                    {
                        await _commandDispatcher.Dispatch(new DeleteMoodCommand
                        {
                            Moods =
                        databaseResocure
                            .Where(x => !serviceResocure.Any(y => y.Id == x.Id))
                        }, default);
                    }
                }
            }
            catch
            {
                //
            }
            finally
            {
                _backgroundJobClientService.Schedule<IPopulateMoodsJob>(x => x.Run(), TimeSpan.FromMinutes(60));
            }

        }
    }
}