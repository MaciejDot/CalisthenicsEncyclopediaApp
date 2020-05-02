using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public interface IFatiguesRepository
    {
        Task<IEnumerable<FatigueDTO>> GetAll();
    }
}