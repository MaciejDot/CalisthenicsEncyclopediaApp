using System.Threading.Tasks;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public interface IPopulateFatiguesJob
    {
        Task Run();
    }
}