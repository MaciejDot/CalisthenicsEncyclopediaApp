using System.Threading.Tasks;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task AddUserIfNotExists(string username);
    }
}