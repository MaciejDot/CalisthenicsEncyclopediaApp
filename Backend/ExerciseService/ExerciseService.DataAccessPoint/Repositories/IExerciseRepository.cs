using ExerciseService.DataAccessPoint.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseService.DataAccessPoint.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<RepositoryExerciseDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
