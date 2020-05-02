using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccessPoint.Cache
{
    public sealed class ExerciseCacheService : IExerciseCacheService
    {
        private readonly ICacheManager<IEnumerable<ExerciseDTO>> _cacheManager;
        private static readonly string _cacheKey = nameof(ExerciseDTO);
        public ExerciseCacheService(ICacheManager<IEnumerable<ExerciseDTO>> cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public CacheItem<IEnumerable<ExerciseDTO>> GetAll()
        {
            return _cacheManager.GetCacheItem(_cacheKey);
        }

        public void Put(IEnumerable<ExerciseDTO> exerciseDTOs)
        {
            _cacheManager.Put(_cacheKey, exerciseDTOs);
        }
    }
}