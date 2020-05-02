using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Cache
{
    public sealed class UserCacheService : IUserCacheService
    {
        private readonly ICacheManager<UserDTO> _cacheManager;

        public UserCacheService(ICacheManager<UserDTO> cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public CacheItem<UserDTO> GetUser(string username)
        {
            return _cacheManager.GetCacheItem(username);
        }

        public void PutUser(UserDTO userDTO)
        {
            _cacheManager.Put(userDTO.Name, userDTO);
        }

    }
}
