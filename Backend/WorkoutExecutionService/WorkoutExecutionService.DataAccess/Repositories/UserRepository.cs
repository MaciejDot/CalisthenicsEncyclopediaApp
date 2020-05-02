using SimpleCQRS.Command;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Cache;
using WorkoutExecutionService.DataAccess.Database.Command;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IUserCacheService _userCacheService;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryProcessor _queryProcessor;
        public UserRepository(
            IUserCacheService userCacheService,
            ICommandDispatcher commandDispatcher,
            IQueryProcessor queryProcessor
        )
        {
            _userCacheService = userCacheService;
            _commandDispatcher = commandDispatcher;
            _queryProcessor = queryProcessor;
        }

        public async Task AddUserIfNotExists(string username)
        {
            if (_userCacheService.GetUser(username) == null)
            {
                _userCacheService.PutUser(new UserDTO { Name = username });
                if (await _queryProcessor.Process(new GetUserQuery { Name = username }, default) == null)
                {
                    await _commandDispatcher.Dispatch(new AddUserCommand { Name = username }, default);
                }
            }
        }
    }
}
