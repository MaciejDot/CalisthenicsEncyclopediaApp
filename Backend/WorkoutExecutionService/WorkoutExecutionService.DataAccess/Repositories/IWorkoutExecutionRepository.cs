using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public interface IWorkoutExecutionRepository
    {
        Task AddWorkoutPlanAsync(string username, WorkoutExecutionDTO workout);
        Task DeleteWorkoutPlanAsync(string username, Guid externalId);
        Task<IEnumerable<WorkoutExecutionDTO>> GetAllUserWorkutPlansAsync(string username);
        Task UpdateWorkoutPlanAsync(string username, WorkoutExecutionDTO workout);
    }
}