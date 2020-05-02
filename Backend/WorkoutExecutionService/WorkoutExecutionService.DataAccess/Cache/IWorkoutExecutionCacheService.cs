using CacheManager.Core;
using System.Collections.Generic;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Cache
{
    public interface IWorkoutExecutionCacheService
    {
        CacheItem<IEnumerable<WorkoutExecutionDTO>> Get(string username);
        void Put(string username, IEnumerable<WorkoutExecutionDTO> workouts);
    }
}