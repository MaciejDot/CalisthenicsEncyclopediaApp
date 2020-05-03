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
using WorkoutExecutionService.DataAccess.Providers;

namespace WorkoutExecutionService.DataAccess.Database.CommandHandler
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AddUserCommandHandler(SqlConnection sqlConnection, IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _sqlConnection = sqlConnection;
        }

        public Task Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            return _sqlConnection.ExecuteAsync(
                "[Security].[sp_User_Add]",
                new
                {
                    command.Name,
                    Created = _dateTimeProvider.GetDate()
                }
                ,
                commandType: CommandType.StoredProcedure
                );
        }
    }
}
