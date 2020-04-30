using CacheManager.Core;
using MoodService.DataAccess.DTO;
using System.Collections.Generic;

namespace MoodService.DataAccess.Cache
{
    public interface IMoodCacheService
    {
        CacheItem<IEnumerable<MoodDTO>> Get();
        void Put(IEnumerable<MoodDTO> moods);
    }
}