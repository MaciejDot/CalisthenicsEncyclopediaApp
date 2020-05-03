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
using WorkoutExecutionService.Domain.DTO;

namespace WorkoutExecutionService.Domain.CommandHandler
{
    public class AddWorkoutExecutionCommandHandler : IRequestHandler<AddWorkoutExecutionCommand, WorkoutExecutionIdentificationDTO>
    {
        private readonly IGuidProvider _guidProvider;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IWorkoutExecutionRepository _workoutExecutionRepository;

        public AddWorkoutExecutionCommandHandler(
            IGuidProvider guidProvider,
            IDateTimeProvider dateTimeProvider,
            IWorkoutExecutionRepository workoutExecutionRepository
            )
        {
            _dateTimeProvider = dateTimeProvider;
            _guidProvider = guidProvider;
            _workoutExecutionRepository = workoutExecutionRepository;
        }

        public async Task<WorkoutExecutionIdentificationDTO> Handle(AddWorkoutExecutionCommand request, CancellationToken cancellationToken)
        {
            var identification  = new WorkoutExecutionIdentificationDTO { ExternalId = _guidProvider.GetGuid() };
            await _workoutExecutionRepository.AddWorkoutPlanAsync(
                request.Username,
                new DataAccess.DTO.WorkoutExecutionDTO {
                    ExternalId = identification.ExternalId,
                    Exercises = request.Exercises.Select(x=> new DataAccess.DTO.ExerciseExecutionDTO {
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
                    Name = request.WorkoutName,
                    Executed = request.Executed
                }
                );
            return identification;
        }
    }
}
