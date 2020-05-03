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
using WorkoutExecutionService.DataAccess.DTO;
using WorkoutExecutionService.DataAccess.Providers;

namespace WorkoutExecutionService.DataAccess.Database.CommandHandler
{
    public class AddWorkoutExecutionCommandHandler : ICommandHandler<AddWorkoutExecutionCommand>
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IGuidProvider _guidProvider;

        public AddWorkoutExecutionCommandHandler(SqlConnection sqlConnection,
            IGuidProvider guidProvider)
        {
            _guidProvider = guidProvider;
            _sqlConnection = sqlConnection;
        }

        public async Task Handle(AddWorkoutExecutionCommand command, CancellationToken cancellationToken)
        {
            var workoutExecutionId = _guidProvider.GetGuid();
            await SaveWorkout(workoutExecutionId, command.Username, command.Workout);
            await SaveExercises(workoutExecutionId, command.Workout.Exercises);
        }

        private Task SaveWorkout(Guid workoutExecutionId, string username, WorkoutExecutionDTO workoutExecutionDTO)
        {
            return _sqlConnection.ExecuteAsync("[Workout].[sp_WorkoutExecutions_Add]", new
            {
                WorkoutName = workoutExecutionDTO.Name,
                workoutExecutionDTO.IsPublic,
                workoutExecutionDTO.Created,
                workoutExecutionDTO.Description,
                workoutExecutionDTO.ExternalId,
                Username = username,
                WorkouExecutionVersionId = workoutExecutionId,
                IsActive = true,
            },
                commandType: CommandType.StoredProcedure);
        }

        private Task SaveExercises(Guid workoutExecutionId, IEnumerable<ExerciseExecutionDTO> exerciseDTOs)
        {
            return _sqlConnection.ExecuteAsync("[Workout].[sp_ExerciseExecutions_Add]",
                exerciseDTOs.Select(x => new
                {
                    WorkoutExecutionVersionId = workoutExecutionId,
                    x.AdditionalKgs,
                    x.Reps,
                    x.Order,
                    x.Series,
                    x.Description,
                    x.Break,
                    x.ExerciseId
                }),
            commandType: CommandType.StoredProcedure);
        }

    }
}
