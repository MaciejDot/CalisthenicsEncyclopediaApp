using CacheManager.Core;
using MoodService.DataAccess.Cache;
using MoodService.DataAccess.DTO;
using MoodService.DataAccess.Hangfire;
using MoodService.DataAccess.Jobs;
using MoodService.Database.Query;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoodService.DataAccess.Repositories
{
    public class MoodRepository : IMoodRepository
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IMoodCacheService _moodCacheService;
        private readonly IBackgroundJobClientService _backgroundJobClientService;

        public MoodRepository(
            IQueryProcessor queryProcessor,
            IMoodCacheService moodCacheService,
            IBackgroundJobClientService backgroundJobClientService
            )
        {
            _moodCacheService = moodCacheService;
            _queryProcessor = queryProcessor;
            _backgroundJobClientService = backgroundJobClientService;
        }

        public Task<IEnumerable<MoodDTO>> GetAllAsync()
        {
            var cacheItem = _moodCacheService.Get();
            return HandleNullCacheItem(cacheItem);
        }

        private async Task<IEnumerable<MoodDTO>> HandleNullCacheItem(CacheItem<IEnumerable<MoodDTO>> cacheItem) 
        {
            if (cacheItem == null)
            {
                return await GetMoodsFromDatabase();
            }
            else
            {
                HandleCloseToExpiration(cacheItem);
                return cacheItem.Value;
            }
        }

        private async Task<IEnumerable<MoodDTO>> GetMoodsFromDatabase() 
        {
            var moods = await _queryProcessor.Process(new GetMoodsQuery(), default);
            _moodCacheService.Put(moods);
            return moods;
        }

        private void HandleCloseToExpiration(CacheItem<IEnumerable<MoodDTO>> cacheItem) 
        {
            if (cacheItem.ExpirationTimeout < TimeSpan.FromMinutes(10))
            {
                _backgroundJobClientService.Enqueue<IPopulateMoodCacheJob>(x => x.Run());
            }
        }

    }
}
