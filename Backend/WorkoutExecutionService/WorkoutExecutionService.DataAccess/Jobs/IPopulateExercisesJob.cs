using System.Threading.Tasks;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public interface IPopulateExercisesJob
    {
        Task Run();
    }
}