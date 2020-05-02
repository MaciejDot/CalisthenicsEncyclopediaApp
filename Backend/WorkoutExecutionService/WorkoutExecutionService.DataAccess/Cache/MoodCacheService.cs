using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccessPoint.Cache
{
    public sealed class MoodCacheService : IMoodCacheService
    {
        private readonly ICacheManager<IEnumerable<MoodDTO>> _cacheManager;
        private static readonly string _cacheKey = nameof(MoodDTO);
        public MoodCacheService(ICacheManager<IEnumerable<MoodDTO>> cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public CacheItem<IEnumerable<MoodDTO>> GetAll()
        {
            return _cacheManager.GetCacheItem(_cacheKey);
        }

        public void Put(IEnumerable<MoodDTO> moodDTOs)
        {
            _cacheManager.Put(_cacheKey, moodDTOs);
        }
    }
}