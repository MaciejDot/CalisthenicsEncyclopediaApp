using Dapper;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.QueryHandler
{
    public class GetExercisesQueryHandler : IQueryHandler<GetExercisesQuery, IEnumerable<ExerciseDTO>>
    {
        private readonly SqlConnection _sqlConnection;
        public GetExercisesQueryHandler(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Task<IEnumerable<ExerciseDTO>> Handle(GetExercisesQuery query, CancellationToken cancellationToken)
        {
            return _sqlConnection.QueryAsync<ExerciseDTO>("[Workout].[sp_Exercise_GetAll]", commandType: CommandType.StoredProcedure);
        }
    }
}
