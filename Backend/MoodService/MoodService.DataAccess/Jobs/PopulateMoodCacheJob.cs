using MoodService.DataAccess.Cache;
using MoodService.Database.Query;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoodService.DataAccess.Jobs
{
    public class PopulateMoodCacheJob : IPopulateMoodCacheJob
    {
        private readonly IMoodCacheService _moodCacheService;
        private readonly IQueryProcessor _queryProcessor;

        public PopulateMoodCacheJob(IMoodCacheService moodCacheService, IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
            _moodCacheService = moodCacheService;
        }

        public async Task Run()
        {
            var moods = await _queryProcessor.Process(new GetMoodsQuery(), default);
            _moodCacheService.Put(moods);
        }
    }
}
