using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Cache;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.Hangfire;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public class PopulateWorkoutsJob : IPopulateWorkoutsJob
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IWorkoutExecutionCacheService _workoutExecutionCacheService;
        private readonly IBackgroundJobClientService _backgroundJobClientService;

        public PopulateWorkoutsJob(IQueryProcessor queryProcessor, IWorkoutExecutionCacheService workoutExecutionCacheService, IBackgroundJobClientService backgroundJobClientService)
        {
            _queryProcessor = queryProcessor;
            _workoutExecutionCacheService = workoutExecutionCacheService;
            _backgroundJobClientService = backgroundJobClientService;
        }

        public async Task Run()
        {
            var workouts = await _queryProcessor.Process(new GetAllWorkoutsExecutionsQuery(), default);
            workouts
                    .AsParallel()
                    .ForAll(workout => _workoutExecutionCacheService.Put(workout.Key, workout.Value));
            _backgroundJobClientService.Schedule<IPopulateWorkoutsJob>(x => x.Run(), TimeSpan.FromMinutes(9));
        }
    }
}
