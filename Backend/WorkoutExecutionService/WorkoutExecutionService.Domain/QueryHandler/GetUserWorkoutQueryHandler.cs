using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Providers;
using WorkoutExecutionService.DataAccess.Repositories;
using WorkoutExecutionService.Domain.DTO;
using WorkoutExecutionService.Domain.Query;

namespace WorkoutExecutionService.Domain.QueryHandler
{
    public class GetUserWorkoutQueryHandler : IRequestHandler<GetUserWorkoutQuery, WorkoutExecutionDTO>
    {
        private readonly IGuidProvider _guidProvider;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IWorkoutExecutionRepository _workoutExecutionRepository;

        public GetUserWorkoutQueryHandler(
            IGuidProvider guidProvider,
            IDateTimeProvider dateTimeProvider,
            IWorkoutExecutionRepository workoutExecutionRepository
            )
        {
            _dateTimeProvider = dateTimeProvider;
            _guidProvider = guidProvider;
            _workoutExecutionRepository = workoutExecutionRepository;
        }

        public async Task<WorkoutExecutionDTO> Handle(GetUserWorkoutQuery request, CancellationToken cancellationToken)
        {
            var workouts = await _workoutExecutionRepository.GetAllUserWorkutPlansAsync(request.OwnerName);
            var workout = workouts.First(x => x.ExternalId == request.ExternalId);
            if (!workout.IsPublic || request.IssuerName != request.OwnerName) 
            {
                throw new Exception();
            }
            return new WorkoutExecutionDTO
            {
                Created = workout.Created,
                Description = workout.Description,
                Exercises = workout.Exercises.Select(x => new ExerciseExecutionDTO
                {
                    ExerciseName = x.ExerciseName,
                    ExerciseId = x.ExerciseId,
                    AdditionalKgs = x.AdditionalKgs,
                    Break = x.Break,
                    Description = x.Description,
                    Series = x.Series,
                    Reps = x.Reps,
                    Order = x.Order
                }),
                ExternalId = workout.ExternalId,
                FatigueId = workout.FatigueId,
                IsPublic = workout.IsPublic,
                MoodId = workout.MoodId,
                Name = workout.Name
            };
        }
    }
}
