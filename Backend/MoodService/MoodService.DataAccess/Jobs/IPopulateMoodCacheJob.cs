using System.Threading.Tasks;

namespace MoodService.DataAccess.Jobs
{
    public interface IPopulateMoodCacheJob
    {
        Task Run();
    }
}