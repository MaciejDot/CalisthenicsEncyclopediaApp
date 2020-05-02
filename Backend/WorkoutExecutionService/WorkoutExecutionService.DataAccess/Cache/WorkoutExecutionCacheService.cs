using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Cache
{
    public class WorkoutExecutionCacheService : IWorkoutExecutionCacheService
    {
        private readonly ICacheManager<IEnumerable<WorkoutExecutionDTO>> _cacheManager;
        public WorkoutExecutionCacheService(ICacheManager<IEnumerable<WorkoutExecutionDTO>> cacheManager)
        {
            _cacheManager = cacheManager;
        }
        public CacheItem<IEnumerable<WorkoutExecutionDTO>> Get(string username)
        {
            return _cacheManager.GetCacheItem(username);
        }
        public void Put(string username, IEnumerable<WorkoutExecutionDTO> workouts)
        {
            _cacheManager.Put(username, workouts);
        }
    }
}
