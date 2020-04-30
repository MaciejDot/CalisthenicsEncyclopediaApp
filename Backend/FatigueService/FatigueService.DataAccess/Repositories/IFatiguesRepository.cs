using FatigueService.DataAccess.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatigueService.DataAccess.Repositories
{
    public interface IFatiguesRepository
    {
        Task<IEnumerable<FatigueDTO>> GetAllAsync();
    }
}