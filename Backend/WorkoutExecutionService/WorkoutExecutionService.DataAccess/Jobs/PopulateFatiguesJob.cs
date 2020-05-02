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
    public class PopulateFatiguesJob : IPopulateFatiguesJob
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly FatigueServiceOptions _options;
        private readonly IFatigueCacheService _fatigueCacheService;
        private readonly IRestClient _restClient;
        private readonly IBackgroundJobClientService _backgroundJobClientService;
        public PopulateFatiguesJob(
            IQueryProcessor queryProcessor,
            IOptions<FatigueServiceOptions> options,
            IFatigueCacheService fatigueCacheService,
            IRestClient restClient,
            ICommandDispatcher commandDispatcher,
            IBackgroundJobClientService backgroundJobClientService
            )
        {
            _fatigueCacheService = fatigueCacheService;
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
                var databaseResocure = await _queryProcessor.Process(new GetFatiguesQuery(), default);
                var request = new RestRequest(_options.ResocureAddress, Method.GET);
                var response = await _restClient.ExecuteAsync<IEnumerable<FatigueDTO>>(request);
                if (!response.IsSuccessful)
                {
                    _fatigueCacheService.Put(databaseResocure);
                    throw new Exception("Unsuccesful request");
                }
                var serviceResocure = response.Data;
                if (!serviceResocure.OrderBy(x => x.Id).SequenceEqual(databaseResocure.OrderBy(x => x.Id)))
                {
                    _fatigueCacheService.Put(serviceResocure);
                    if (serviceResocure
                        .Where(x => !databaseResocure.Any(y => y.Id == x.Id && x.Name == y.Name)).Any())
                    {
                        await _commandDispatcher.Dispatch(new AddFatigueCommand
                        {
                            Fatigues =
                        serviceResocure
                            .Where(x => !databaseResocure.Any(y => y.Id == x.Id && x.Name == y.Name))
                        }, default);
                    }

                    if (databaseResocure
                        .Where(x => !serviceResocure.Any(y => y.Id == x.Id)).Any())
                    {
                        await _commandDispatcher.Dispatch(new DeleteFatigueCommand
                        {
                            Fatigues =
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
                _backgroundJobClientService.Schedule<IPopulateFatiguesJob>(x => x.Run(), TimeSpan.FromMinutes(60));
            }

        }
    }
}