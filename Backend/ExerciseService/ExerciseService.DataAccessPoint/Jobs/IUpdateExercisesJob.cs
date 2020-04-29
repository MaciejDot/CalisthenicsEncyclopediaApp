using System.Threading;
using System.Threading.Tasks;

namespace ExerciseService.DataAccessPoint.Jobs
{
    public interface IUpdateExercisesJob
    {
        Task Run(CancellationToken cancellationToken);
    }
}