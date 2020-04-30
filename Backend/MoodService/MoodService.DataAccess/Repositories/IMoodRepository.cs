using MoodService.DataAccess.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoodService.DataAccess.Repositories
{
    public interface IMoodRepository
    {
        Task<IEnumerable<MoodDTO>> GetAllAsync();
    }
}