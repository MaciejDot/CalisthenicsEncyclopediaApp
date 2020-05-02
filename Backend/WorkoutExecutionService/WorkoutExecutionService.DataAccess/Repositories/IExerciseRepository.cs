using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync();
    }
}