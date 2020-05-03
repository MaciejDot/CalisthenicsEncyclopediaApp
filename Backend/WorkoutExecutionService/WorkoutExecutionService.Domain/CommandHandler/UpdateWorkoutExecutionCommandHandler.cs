using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Providers;
using WorkoutExecutionService.DataAccess.Repositories;
using WorkoutExecutionService.Domain.Command;

namespace WorkoutExecutionService.Domain.CommandHandler
{
    public class UpdateWorkoutExecutionCommandHandler : IRequestHandler<UpdateWorkoutExecutionCommand, Unit>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IWorkoutExecutionRepository _workoutExecutionRepository;

        public UpdateWorkoutExecutionCommandHandler(
            IDateTimeProvider dateTimeProvider,
            IWorkoutExecutionRepository workoutExecutionRepository
            )
        {
            _dateTimeProvider = dateTimeProvider;
            _workoutExecutionRepository = workoutExecutionRepository;
        }

        public async Task<Unit> Handle(UpdateWorkoutExecutionCommand request, CancellationToken cancellationToken)
        {
            await _workoutExecutionRepository.UpdateWorkoutPlanAsync(
            request.Username,
            new DataAccess.DTO.WorkoutExecutionDTO
            {
                ExternalId = request.ExternalId,
                Exercises = request.Exercises.Select(x => new DataAccess.DTO.ExerciseExecutionDTO
                {
                    AdditionalKgs = x.AdditionalKgs,
                    Series = x.Series,
                    Reps = x.Reps,
                    Break = x.Break,
                    Description = x.Description,
                    ExerciseId = x.ExerciseId,
                    ExerciseName = x.ExerciseName,
                    Order = x.Order
                }),
                Created = _dateTimeProvider.GetDate(),
                Description = request.Description,
                FatigueId = request.FatigueId,
                MoodId = request.MoodId,
                IsPublic = request.IsPublic,
                Name = request.Name,
                Executed = request.Executed
            }
            );
            return new Unit();
        }
    }
}
