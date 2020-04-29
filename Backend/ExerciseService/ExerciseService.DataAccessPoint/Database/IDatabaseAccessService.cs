using ExerciseService.DataAccessPoint.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseService.DataAccessPoint.Database
{
    public interface IDatabaseAccessService
    {
        Task<IEnumerable<RepositoryExerciseDTO>> GetAllExercises();
    }
}