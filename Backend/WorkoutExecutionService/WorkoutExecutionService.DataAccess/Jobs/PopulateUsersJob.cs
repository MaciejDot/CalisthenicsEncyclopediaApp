using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Cache;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.Hangfire;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public class PopulateUsersJob : IPopulateUsersJob
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IUserCacheService _userCacheService;
        private readonly IBackgroundJobClientService _backgroundJobClientService;
        public PopulateUsersJob(IQueryProcessor queryProcessor,
            IUserCacheService userCacheService,
            IBackgroundJobClientService backgroundJobClientService)
        {
            _queryProcessor = queryProcessor;
            _userCacheService = userCacheService;
            _backgroundJobClientService = backgroundJobClientService;
        }

        public async Task Run()
        {
            var users = await _queryProcessor.Process(new GetUsersQuery(), default);
            users
                .AsParallel()
                .ForAll(user => _userCacheService.PutUser(user));
            _backgroundJobClientService.Schedule<IPopulateUsersJob>(x => x.Run(), TimeSpan.FromMinutes(9));
        }
    }
}
