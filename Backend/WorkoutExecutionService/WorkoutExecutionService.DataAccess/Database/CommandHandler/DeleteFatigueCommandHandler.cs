using Dapper;
using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Command;
using WorkoutExecutionService.DataAccess.Providers;

namespace WorkoutExecutionService.DataAccess.Database.CommandHandler
{
    public class DeleteFatigueCommandHandler : ICommandHandler<DeleteFatigueCommand>
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDateTimeProvider _dateTimeProvider;
        public DeleteFatigueCommandHandler(SqlConnection sqlConnection,
            IDateTimeProvider dateTimeProvider)
        {
            _sqlConnection = sqlConnection;
            _dateTimeProvider = dateTimeProvider;
        }

        public Task Handle(DeleteFatigueCommand command, CancellationToken cancellationToken)
        {
            var date = _dateTimeProvider.GetDate();
            return _sqlConnection.ExecuteAsync("[Workout].[sp_Fatigue_Add]",
                command.Fatigues.Select(x => new {
                    FatigueId = x.Id,
                    x.Name,
                    Created = date,
                    IsActive = false
                }),
                commandType: CommandType.StoredProcedure);
        }
    }
}
