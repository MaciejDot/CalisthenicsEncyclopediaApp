using System;
using System.Threading.Tasks;

namespace WorkoutExecutionService.DataAccess.Jobs
{
    public interface IDeleteWorkoutExecutionJob
    {
        Task Run(DateTime created, string username, Guid externalId);
    }
}