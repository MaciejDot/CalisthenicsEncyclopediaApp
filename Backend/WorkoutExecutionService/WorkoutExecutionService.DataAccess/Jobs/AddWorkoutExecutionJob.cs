using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Command;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public sealed class AddWorkoutExecutionJob : IAddWorkoutExecutionJob
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AddWorkoutExecutionJob(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public async Task Run(string username, WorkoutExecutionDTO workoutExecutionDTO)
        {
            await _commandDispatcher.Dispatch(new AddWorkoutExecutionCommand { Username = username, Workout = workoutExecutionDTO }, default);
        }
    }
}
