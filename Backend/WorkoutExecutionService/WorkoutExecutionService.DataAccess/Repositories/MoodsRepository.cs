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
    public sealed class MoodsRepository : IMoodsRepository
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IMoodCacheService _moodCacheService;

        public MoodsRepository(
            IQueryProcessor queryProcessor,
            IMoodCacheService moodCacheService)
        {
            _queryProcessor = queryProcessor;
            _moodCacheService = moodCacheService;
        }

        public Task<IEnumerable<MoodDTO>> GetAll()
        {
            var cachedItem = _moodCacheService.GetAll();
            return HandleReturnedCacheItem(cachedItem);
        }

        private async Task<IEnumerable<MoodDTO>> HandleReturnedCacheItem(CacheItem<IEnumerable<MoodDTO>> cacheItem)
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

        private async Task<IEnumerable<MoodDTO>> HandleNullCacheItem(CacheItem<IEnumerable<MoodDTO>> cacheItem)
        {
            var databaseResocure = await _queryProcessor.Process(new GetMoodsQuery(), default);
            _moodCacheService.Put(databaseResocure);
            return databaseResocure;
        }


    }
}