using CacheManager.Core;
using System.Collections.Generic;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccessPoint.Cache
{
    public interface IMoodCacheService
    {
        CacheItem<IEnumerable<MoodDTO>> GetAll();
        void Put(IEnumerable<MoodDTO> moodDTOs);
    }
}