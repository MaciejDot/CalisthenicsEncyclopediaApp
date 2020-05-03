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
    public class GetMoodsQueryHandler : IQueryHandler<GetMoodsQuery, IEnumerable<MoodDTO>>
    {
        private readonly SqlConnection _sqlConnection;
        public GetMoodsQueryHandler(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Task<IEnumerable<MoodDTO>> Handle(GetMoodsQuery query, CancellationToken cancellationToken)
        {
            return _sqlConnection.QueryAsync<MoodDTO>("[Workout].[sp_Mood_GetAll]", commandType: CommandType.StoredProcedure);
        }
    }
}
