using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Command;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public sealed class DeleteWorkoutExecutionJob : IDeleteWorkoutExecutionJob
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public DeleteWorkoutExecutionJob(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public async Task Run(DateTime created, string username, Guid externalId)
        {
            await _commandDispatcher.Dispatch(new DeleteWorkoutExecutionCommand { Created = created, Username = username, ExternalId = externalId }, default);
        }
    }
}
