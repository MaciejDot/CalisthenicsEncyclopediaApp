using Dapper;
using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Command;
using WorkoutExecutionService.DataAccess.Providers;

namespace WorkoutExecutionService.DataAccess.Database.CommandHandler
{
    public class AddExercisesCommandHandler : ICommandHandler<AddExercisesCommand>
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDateTimeProvider _dateTimeProvider;
        public AddExercisesCommandHandler(SqlConnection sqlConnection,
            IDateTimeProvider dateTimeProvider)
        {
            _sqlConnection = sqlConnection;
            _dateTimeProvider = dateTimeProvider;
        }

        public Task Handle(AddExercisesCommand command, CancellationToken cancellationToken)
        {
            var date = _dateTimeProvider.GetDate();
            return _sqlConnection.ExecuteAsync("[Workout].[sp_Exercise_Add]", 
                command.Exercises.Select(x=> new {
                    ExerciseId = x.Id,
                    x.Name,
                    Created = date,
                    IsActive = true
                }), 
                commandType : CommandType.StoredProcedure);
        }
    }
}
