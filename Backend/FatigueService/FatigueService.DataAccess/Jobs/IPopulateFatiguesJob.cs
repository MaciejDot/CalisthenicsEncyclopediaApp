using System.Threading.Tasks;

namespace FatigueService.DataAccess.Jobs
{
    public interface IPopulateFatiguesJob
    {
        Task Run();
    }
}