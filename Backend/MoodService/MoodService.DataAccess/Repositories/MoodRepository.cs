using MoodService.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoodService.DataAccess.Repositories
{
    public class MoodRepository
    {
        public Task<IEnumerable<MoodDTO>> GetAllAsync() 
        {
            throw new Exception();
        }
    }
}
