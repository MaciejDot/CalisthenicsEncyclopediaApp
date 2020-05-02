using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public interface IAddWorkoutExecutionJob
    {
        Task Run(string username, WorkoutExecutionDTO workoutExecutionDTO);
    }
}