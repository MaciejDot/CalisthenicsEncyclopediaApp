using CacheManager.Core;
using System.Collections.Generic;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccessPoint.Cache
{
    public interface IExerciseCacheService
    {
        CacheItem<IEnumerable<ExerciseDTO>> GetAll();
        void Put(IEnumerable<ExerciseDTO> exerciseDTOs);
    }
}