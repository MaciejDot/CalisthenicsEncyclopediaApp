using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public interface IUpdateWorkoutExecutionJob
    {
        Task Run(string username, WorkoutExecutionDTO workoutExecutionDTO);
    }
}