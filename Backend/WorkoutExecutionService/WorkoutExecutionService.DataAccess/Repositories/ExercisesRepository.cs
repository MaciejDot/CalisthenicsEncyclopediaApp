using CacheManager.Core;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.DTO;
using WorkoutExecutionService.DataAccess.Hangfire;
using WorkoutExecutionService.DataAccessPoint.Cache;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public sealed class ExerciseRepository : IExerciseRepository
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IExerciseCacheService _exerciseCacheService;

        public ExerciseRepository(
            IQueryProcessor queryProcessor,
            IExerciseCacheService exerciseCacheService)
        {
            _queryProcessor = queryProcessor;
            _exerciseCacheService = exerciseCacheService;
        }

        public Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync()
        {
            var cachedItem = _exerciseCacheService.GetAll();
            return HandleReturnedCacheItem(cachedItem);
        }

        private async Task<IEnumerable<ExerciseDTO>> HandleReturnedCacheItem(CacheItem<IEnumerable<ExerciseDTO>> cacheItem)
        {
            if (cacheItem == null)
            {
                return await HandleNullCacheItem(cacheItem);
            }
            else
            {
                return cacheItem.Value;
            }
        }

        private async Task<IEnumerable<ExerciseDTO>> HandleNullCacheItem(CacheItem<IEnumerable<ExerciseDTO>> cacheItem)
        {
            var exercisesFromDatabase = await _queryProcessor.Process(new GetExercisesQuery(), default);
            _exerciseCacheService.Put(exercisesFromDatabase);
            return exercisesFromDatabase;
        }


    }
}