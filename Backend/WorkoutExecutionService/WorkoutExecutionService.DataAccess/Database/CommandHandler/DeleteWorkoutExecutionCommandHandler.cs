using Dapper;
using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Command;

namespace WorkoutExecutionService.DataAccess.Database.CommandHandler
{
    public class DeleteWorkoutExecutionCommandHandler : ICommandHandler<DeleteWorkoutExecutionCommand>
    {
        private readonly SqlConnection _sqlConnection;
        public DeleteWorkoutExecutionCommandHandler(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Task Handle(DeleteWorkoutExecutionCommand command, CancellationToken cancellationToken)
        {
            return _sqlConnection.ExecuteAsync("[Workout].[sp_WorkoutExecutions_Delete]", command, commandType: CommandType.StoredProcedure);
        }
    }
}
