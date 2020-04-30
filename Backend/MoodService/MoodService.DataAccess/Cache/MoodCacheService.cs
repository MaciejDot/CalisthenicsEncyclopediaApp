using CacheManager.Core;
using MoodService.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodService.DataAccess.Cache
{
    public class MoodCacheService : IMoodCacheService
    {
        private readonly string _key = "mood";
        private readonly ICacheManager<IEnumerable<MoodDTO>> _cacheManager;

        public MoodCacheService(ICacheManager<IEnumerable<MoodDTO>> cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public CacheItem<IEnumerable<MoodDTO>> Get()
        {
            return _cacheManager.GetCacheItem(_key);
        }

        public void Put(IEnumerable<MoodDTO> moods)
        {
            _cacheManager.Put(_key, moods);
        }
    }
}
