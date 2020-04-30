using CacheManager.Core;
using FatigueService.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatigueService.DataAccess.Cache
{
    public class FatigueCacheService : IFatigueCacheService
    {
        private readonly string _key = "fatigue";
        private readonly ICacheManager<IEnumerable<FatigueDTO>> _cacheManager;

        public FatigueCacheService(ICacheManager<IEnumerable<FatigueDTO>> cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public CacheItem<IEnumerable<FatigueDTO>> Get()
        {
            return _cacheManager.GetCacheItem(_key);
        }

        public void Put(IEnumerable<FatigueDTO> fatigueDTOs)
        {
            _cacheManager.Put(_key, fatigueDTOs);
        }
    }
}
