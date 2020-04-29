using CacheManager.Core;
using ExerciseService.DataAccessPoint.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseService.DataAccessPoint.Cache
{
    public class CacheAccessService : ICacheAccessService
    {
        private readonly ICacheManager<IEnumerable<RepositoryExerciseDTO>> _cacheManager;
        private string CacheKeyForAllExercises
        {
            get
            {
                return "exercises";
            }
        }

        public CacheAccessService(
            ICacheManager<IEnumerable<RepositoryExerciseDTO>> cacheManager
            )
        {
            _cacheManager = cacheManager;
        }

        public CacheItem<IEnumerable<RepositoryExerciseDTO>> GetExercisesFromCache()
        {
            return _cacheManager.GetCacheItem(CacheKeyForAllExercises);
        }

        public void AddExercisesToCache(IEnumerable<RepositoryExerciseDTO> exercises)
        {
            _cacheManager.Add(CacheKeyForAllExercises, exercises);
        }

        public void SetExercises(IEnumerable<RepositoryExerciseDTO> exercises)
        {
            _cacheManager.Remove(CacheKeyForAllExercises);
            _cacheManager.Add(CacheKeyForAllExercises, exercises);
        }
    }
}
