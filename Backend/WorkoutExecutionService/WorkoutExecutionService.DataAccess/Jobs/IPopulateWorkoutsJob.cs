using System.Threading.Tasks;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public interface IPopulateWorkoutsJob
    {
        Task Run();
    }
}