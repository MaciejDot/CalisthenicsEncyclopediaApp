using SimpleCQRS.Command;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.Command
{
    public class AddWorkoutExecutionCommand : ICommand
    {
        public WorkoutExecutionDTO Workout { get; set; }
        public string Username { get; set; }
    }
}
