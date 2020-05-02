using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccessPoint.Cache
{
    public sealed class FatigueCacheService : IFatigueCacheService
    {
        private readonly ICacheManager<IEnumerable<FatigueDTO>> _cacheManager;
        private static readonly string _cacheKey = nameof(FatigueDTO);
        public FatigueCacheService(ICacheManager<IEnumerable<FatigueDTO>> cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public CacheItem<IEnumerable<FatigueDTO>> GetAll()
        {
            return _cacheManager.GetCacheItem(_cacheKey);
        }

        public void Put(IEnumerable<FatigueDTO> fatiguesDTOs)
        {
            _cacheManager.Put(_cacheKey, fatiguesDTOs);
        }
    }
}