using CacheManager.Core;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Cache
{
    public interface IUserCacheService
    {
        CacheItem<UserDTO> GetUser(string username);
        void PutUser(UserDTO userDTO);
    }
}