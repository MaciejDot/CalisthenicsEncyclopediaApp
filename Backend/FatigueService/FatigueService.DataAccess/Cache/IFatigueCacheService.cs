using CacheManager.Core;
using FatigueService.DataAccess.DTO;
using System.Collections.Generic;

namespace FatigueService.DataAccess.Cache
{
    public interface IFatigueCacheService
    {
        CacheItem<IEnumerable<FatigueDTO>> Get();
        void Put(IEnumerable<FatigueDTO> fatigueDTOs);
    }
}