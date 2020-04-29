using CacheManager.Core;
using ExerciseService.DataAccessPoint.DTO;
using System.Collections.Generic;

namespace ExerciseService.DataAccessPoint.Cache
{
    public interface ICacheAccessService
    {
        void AddExercisesToCache(IEnumerable<RepositoryExerciseDTO> exercises);
        CacheItem<IEnumerable<RepositoryExerciseDTO>> GetExercisesFromCache();
        void SetExercises(IEnumerable<RepositoryExerciseDTO> exercises);
    }
}