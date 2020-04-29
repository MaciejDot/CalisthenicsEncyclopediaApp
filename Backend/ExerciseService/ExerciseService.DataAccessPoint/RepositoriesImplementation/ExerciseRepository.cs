using CacheManager.Core;
using ExerciseService.DataAccessPoint.Cache;
using ExerciseService.DataAccessPoint.Database;
using ExerciseService.DataAccessPoint.DTO;
using ExerciseService.DataAccessPoint.Hangfire;
using ExerciseService.DataAccessPoint.Jobs;
using ExerciseService.DataAccessPoint.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseService.DataAccessPoint.RepositoriesImplementation
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IDatabaseAccessService _databaseAccessService;
        private readonly IBackgroundJobClientService _backgroundJobClientService;
        private readonly ICacheAccessService _cacheAccessService;
        public ExerciseRepository(
            IDatabaseAccessService databaseAccessService,
            IBackgroundJobClientService backgroundJobClientService,
            ICacheAccessService cacheAccessService)
        {
            _databaseAccessService = databaseAccessService;
            _backgroundJobClientService = backgroundJobClientService;
            _cacheAccessService = cacheAccessService;
        }

        public Task<IEnumerable<RepositoryExerciseDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var cachedItem = _cacheAccessService.GetExercisesFromCache();
            return HandleReturnedCacheItem(cachedItem);
        }

        private async Task<IEnumerable<RepositoryExerciseDTO>> HandleReturnedCacheItem(CacheItem<IEnumerable<RepositoryExerciseDTO>> cacheItem)
        {
            if (cacheItem == null)
            {
                return await HandleNullCacheItem(cacheItem);
            }
            else
            {
                HandleCloseToExpiration(cacheItem);
                return cacheItem.Value;
            }
        }

        private async Task<IEnumerable<RepositoryExerciseDTO>> HandleNullCacheItem(CacheItem<IEnumerable<RepositoryExerciseDTO>> cacheItem)
        {
            var exercisesFromDatabase = await _databaseAccessService.GetAllExercises();
            _cacheAccessService.AddExercisesToCache(exercisesFromDatabase);
            return exercisesFromDatabase;
        }

        private void HandleCloseToExpiration(CacheItem<IEnumerable<RepositoryExerciseDTO>> cacheItem)
        {
            if (cacheItem.ExpirationTimeout < TimeSpan.FromMinutes(30))
            {
                ScheduleUpdateJob();
            }
        }

        private void ScheduleUpdateJob()
        {
            _backgroundJobClientService.Enqueue<IUpdateExercisesJob>(x => x.Run(default));
        }
    }
}
