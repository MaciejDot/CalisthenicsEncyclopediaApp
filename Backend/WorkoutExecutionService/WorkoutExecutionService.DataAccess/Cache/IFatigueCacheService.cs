using CacheManager.Core;
using System.Collections.Generic;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccessPoint.Cache
{
    public interface IFatigueCacheService
    {
        CacheItem<IEnumerable<FatigueDTO>> GetAll();
        void Put(IEnumerable<FatigueDTO> fatiguesDTOs);
    }
}