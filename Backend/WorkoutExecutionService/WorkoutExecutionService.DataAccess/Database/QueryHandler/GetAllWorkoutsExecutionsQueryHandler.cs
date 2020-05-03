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
    public class GetAllWorkoutsExecutionsQueryHandler : IQueryHandler<GetAllWorkoutsExecutionsQuery, IDictionary<string, IEnumerable<WorkoutExecutionDTO>>>
    {
        private readonly SqlConnection _sqlConnection;
        
        public GetAllWorkoutsExecutionsQueryHandler(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IDictionary<string, IEnumerable<WorkoutExecutionDTO>>> Handle(GetAllWorkoutsExecutionsQuery query, CancellationToken cancellationToken)
        {
            var rawWorkouts = await GetAllRawWorkoutExecutionsFromDatabase();
            return rawWorkouts
                .GroupBy(x => x.Item1.Username)
                .ToDictionary(x => x.Key, x => FormatFetchedWorkouts(x.Select(y => (y.Item2, y.Item3))));
        }

        private IEnumerable<WorkoutExecutionDTO> FormatFetchedWorkouts(IEnumerable<(WorkoutExecutionDTO, ExerciseExecutionDTO)> rawWorkoutPlans)
        {
            return rawWorkoutPlans
                    .GroupBy(x => new
                    {
                        x.Item1.Name,
                        x.Item1.Created,
                        x.Item1.Description,
                        x.Item1.IsPublic,
                        x.Item1.ExternalId
                    })
                    .Select(x => new WorkoutExecutionDTO
                    {
                        Name = x.Key.Name,
                        Created = x.Key.Created,
                        Description = x.Key.Description,
                        Exercises = x.Where(x => x.Item2 != null).Select(x => x.Item2),
                        IsPublic = x.Key.IsPublic,
                        ExternalId = x.Key.ExternalId
                    });
        }

        private Task<IEnumerable<(User, WorkoutExecutionDTO, ExerciseExecutionDTO)>> GetAllRawWorkoutExecutionsFromDatabase()
        {
            return _sqlConnection.QueryAsync<User, WorkoutExecutionDTO, ExerciseExecutionDTO, (User, WorkoutExecutionDTO, ExerciseExecutionDTO)>(
                    "[Workout].[sp_WorkoutExecutions_GetAll]",
                     (user, workout, exercise) =>
                     {
                         return (user, workout, exercise);
                     },
                     commandType: CommandType.StoredProcedure);
        }

        private class User
        {
            public string Username { get; set; }
        }
    }
}
