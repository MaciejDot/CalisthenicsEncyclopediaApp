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
    public class PopulateExercisesJob : IPopulateExercisesJob
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ExerciseServiceOptions _options;
        private readonly IExerciseCacheService _exerciseCacheService;
        private readonly IRestClient _restClient;
        private readonly IBackgroundJobClientService _backgroundJobClientService; 
        public PopulateExercisesJob(
            IQueryProcessor queryProcessor,
            IOptions<ExerciseServiceOptions> options,
            IExerciseCacheService exerciseCacheService,
            IRestClient restClient,
            ICommandDispatcher commandDispatcher,
            IBackgroundJobClientService backgroundJobClientService
            )
        {
            _exerciseCacheService = exerciseCacheService;
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
                var databaseExercises = await _queryProcessor.Process(new GetExercisesQuery(), default);
                var request = new RestRequest(_options.ResocureAddress, Method.GET);
                var response = await _restClient.ExecuteAsync<IEnumerable<ExerciseDTO>>(request);
                if (!response.IsSuccessful)
                {
                    _exerciseCacheService.Put(databaseExercises);
                    throw new Exception("Unsuccesful request");
                }
                var exercises = response.Data;
                if (!exercises.OrderBy(x => x.Id).SequenceEqual(databaseExercises.OrderBy(x => x.Id)))
                {
                    _exerciseCacheService.Put(exercises);
                    if (exercises
                        .Where(x => !databaseExercises.Any(y => y.Id == x.Id && x.Name == y.Name)).Any())
                    {
                        await _commandDispatcher.Dispatch(new AddExercisesCommand
                        {
                            Exercises =
                        exercises
                            .Where(x => !databaseExercises.Any(y => y.Id == x.Id && x.Name == y.Name))
                        }, default);
                    }

                    if (databaseExercises
                        .Where(x => !exercises.Any(y => y.Id == x.Id)).Any())
                    {
                        await _commandDispatcher.Dispatch(new DeleteExercisesCommand
                        {
                            Exercises =
                        databaseExercises
                            .Where(x => !exercises.Any(y => y.Id == x.Id))
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
                _backgroundJobClientService.Schedule<IPopulateExercisesJob>(x => x.Run(), TimeSpan.FromMinutes(60));
            }

        }
    }
}
