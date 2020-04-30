using CacheManager.Core;
using FatigueService.DataAccess.Cache;
using FatigueService.DataAccess.Database.Query;
using FatigueService.DataAccess.DTO;
using FatigueService.DataAccess.Hangfire;
using FatigueService.DataAccess.Jobs;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatigueService.DataAccess.Repositories
{
    public class FatiguesRepository : IFatiguesRepository
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IFatigueCacheService _fatigueCacheService;
        private readonly IBackgroundJobClientService _backgroundJobClientService;

        public FatiguesRepository(
            IQueryProcessor queryProcessor,
            IFatigueCacheService fatigueCacheService,
            IBackgroundJobClientService backgroundJobClientService
            )
        {
            _fatigueCacheService = fatigueCacheService;
            _queryProcessor = queryProcessor;
            _backgroundJobClientService = backgroundJobClientService;
        }

        public Task<IEnumerable<FatigueDTO>> GetAllAsync()
        {
            var cacheItem = _fatigueCacheService.Get();
            return HandleNullCacheItem(cacheItem);
        }

        private async Task<IEnumerable<FatigueDTO>> HandleNullCacheItem(CacheItem<IEnumerable<FatigueDTO>> cacheItem)
        {
            if (cacheItem == null)
            {
                return await GetFatiguesFromDatabase();
            }
            else
            {
                HandleCloseToExpiration(cacheItem);
                return cacheItem.Value;
            }
        }

        private async Task<IEnumerable<FatigueDTO>> GetFatiguesFromDatabase()
        {
            var fatigues = await _queryProcessor.Process(new GetFatiguesQuery(), default);
            _fatigueCacheService.Put(fatigues);
            return fatigues;
        }

        private void HandleCloseToExpiration(CacheItem<IEnumerable<FatigueDTO>> cacheItem)
        {
            if (cacheItem.ExpirationTimeout < TimeSpan.FromMinutes(10))
            {
                _backgroundJobClientService.Enqueue<IPopulateFatiguesJob>(x => x.Run());
            }
        }

    }
}
