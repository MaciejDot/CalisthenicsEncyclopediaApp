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
    public class DeleteMoodCommandHandler : ICommandHandler<DeleteMoodCommand>
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDateTimeProvider _dateTimeProvider;
        public DeleteMoodCommandHandler(SqlConnection sqlConnection,
            IDateTimeProvider dateTimeProvider)
        {
            _sqlConnection = sqlConnection;
            _dateTimeProvider = dateTimeProvider;
        }
        public Task Handle(DeleteMoodCommand command, CancellationToken cancellationToken)
        {
            var date = _dateTimeProvider.GetDate();
            return _sqlConnection.ExecuteAsync("[Workout].[sp_Mood_Add]",
                command.Moods.Select(x => new {
                    MoodId = x.Id,
                    x.Name,
                    Created = date,
                    IsActive = false
                }),
                commandType: CommandType.StoredProcedure);
        }
    }
}
