using Dapper;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.QueryHandler
{
    public class GetWorkoutExecutionsQueryHandler : IQueryHandler<GetWorkoutsExecutionsQuery, IEnumerable<WorkoutExecutionDTO>>
    {
        private readonly SqlConnection _sqlConnection;
        public async Task<IEnumerable<WorkoutExecutionDTO>> Handle(GetWorkoutsExecutionsQuery query, CancellationToken cancellationToken)
        {
            var rawExecutions = await GetRawWorkoutExecutionsFromDatabase(query.Username);
            return FormatFetchedWorkouts(rawExecutions);
        }

        private IEnumerable<WorkoutExecutionDTO> FormatFetchedWorkouts(IEnumerable<(WorkoutExecutionDTO, ExerciseExecutionDTO)> rawWorkoutPlans)
        {
            return rawWorkoutPlans
                    .GroupBy(x => new
                    {
                        x.Item1.Name,
                        x.Item1.Created,
                        x.Item1.Description,
                        x.Item1.IsPublic
                    })
                    .Select(x => new WorkoutExecutionDTO
                    {
                        Name = x.Key.Name,
                        Created = x.Key.Created,
                        Description = x.Key.Description,
                        Exercises = x.Where(x => x.Item2 != null).Select(x => x.Item2),
                        IsPublic = x.Key.IsPublic

                    });
        }

        private Task<IEnumerable<(WorkoutExecutionDTO, ExerciseExecutionDTO)>> GetRawWorkoutExecutionsFromDatabase(string username)
        {
            return _sqlConnection.QueryAsync<WorkoutExecutionDTO, ExerciseExecutionDTO, (WorkoutExecutionDTO, ExerciseExecutionDTO)>(
                    "[Workout].[sp_WorkoutExecutions_Get]",
                     (workout, exercise) =>
                     {
                         return (workout, exercise);
                     },
                     new { username },
                     commandType: CommandType.StoredProcedure);
        }
    }
}
