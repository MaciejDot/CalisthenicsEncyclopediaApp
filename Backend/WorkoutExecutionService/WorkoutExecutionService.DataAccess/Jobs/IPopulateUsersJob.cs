using System.Threading.Tasks;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public interface IPopulateUsersJob
    {
        Task Run();
    }
}