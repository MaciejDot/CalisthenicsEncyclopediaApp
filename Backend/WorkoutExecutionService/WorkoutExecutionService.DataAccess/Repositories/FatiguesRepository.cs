using CacheManager.Core;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.DTO;
using WorkoutExecutionService.DataAccess.Hangfire;
using WorkoutExecutionService.DataAccessPoint.Cache;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public sealed class FatiguesRepository : IFatiguesRepository
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IFatigueCacheService _fatiguesCacheService;

        public FatiguesRepository(
            IQueryProcessor queryProcessor,
            IFatigueCacheService fatiguesCacheService)
        {
            _queryProcessor = queryProcessor;
            _fatiguesCacheService = fatiguesCacheService;
        }

        public Task<IEnumerable<FatigueDTO>> GetAll()
        {
            var cachedItem = _fatiguesCacheService.GetAll();
            return HandleReturnedCacheItem(cachedItem);
        }

        private async Task<IEnumerable<FatigueDTO>> HandleReturnedCacheItem(CacheItem<IEnumerable<FatigueDTO>> cacheItem)
        {
            if (cacheItem == null)
            {
                return await HandleNullCacheItem(cacheItem);
            }
            else
            {
                return cacheItem.Value;
            }
        }

        private async Task<IEnumerable<FatigueDTO>> HandleNullCacheItem(CacheItem<IEnumerable<FatigueDTO>> cacheItem)
        {
            var databaseResocure = await _queryProcessor.Process(new GetFatiguesQuery(), default);
            _fatiguesCacheService.Put(databaseResocure);
            return databaseResocure;
        }


    }
}