using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public interface IMoodsRepository
    {
        Task<IEnumerable<MoodDTO>> GetAll();
    }
}