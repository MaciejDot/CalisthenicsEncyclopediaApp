using FatigueService.DataAccess.Cache;
using FatigueService.DataAccess.Database.Query;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatigueService.DataAccess.Jobs
{
    public class PopulateFatiguesJob : IPopulateFatiguesJob
    {
        private readonly IFatigueCacheService _fatigueCacheService;
        private readonly IQueryProcessor _queryProcessor;

        public PopulateFatiguesJob(IFatigueCacheService fatigueCacheService
            , IQueryProcessor queryProcessor)
        {
            _fatigueCacheService = fatigueCacheService;
            _queryProcessor = queryProcessor;
        }

        public async Task Run()
        {
            var fatigues = await _queryProcessor.Process(new GetFatiguesQuery(), default);
            _fatigueCacheService.Put(fatigues);
        }
    }
}
