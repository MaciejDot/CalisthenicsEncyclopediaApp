using System;
using System.Threading.Tasks;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public interface IDeleteWorkoutExecutionJob
    {
        Task Run(string username, Guid externalId);
    }
}