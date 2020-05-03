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
    public class DeleteExercisesCommandHandler : ICommandHandler<DeleteExercisesCommand>
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDateTimeProvider _dateTimeProvider;
        public DeleteExercisesCommandHandler(SqlConnection sqlConnection,
            IDateTimeProvider dateTimeProvider)
        {
            _sqlConnection = sqlConnection;
            _dateTimeProvider = dateTimeProvider;
        }

        public Task Handle(DeleteExercisesCommand command, CancellationToken cancellationToken)
        {
            var date = _dateTimeProvider.GetDate();
            return _sqlConnection.ExecuteAsync("[Workout].[sp_Exercise_Add]",
                command.Exercises.Select(x => new {
                    ExerciseId = x.Id,
                    x.Name,
                    Created = date,
                    IsActive = false
                }),
                commandType: CommandType.StoredProcedure);
        }
    }
}
