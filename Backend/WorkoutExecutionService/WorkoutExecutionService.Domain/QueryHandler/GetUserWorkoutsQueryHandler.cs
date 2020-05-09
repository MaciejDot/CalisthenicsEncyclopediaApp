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
    public class GetUserWorkoutsQueryHandler : IRequestHandler<GetUserWorkoutsQuery, IEnumerable<WorkoutExecutionDTO>>
    {
        private readonly IWorkoutExecutionRepository _workoutExecutionRepository;

        public GetUserWorkoutsQueryHandler(
            IWorkoutExecutionRepository workoutExecutionRepository
            )
        {
            _workoutExecutionRepository = workoutExecutionRepository;
        }

        public async Task<IEnumerable<WorkoutExecutionDTO>> Handle(GetUserWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var workouts = await _workoutExecutionRepository.GetAllUserWorkutPlansAsync(request.Username);
            return workouts.Select( workout =>new WorkoutExecutionDTO
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
                Fatigue = workout.FatigueId,
                IsPublic = workout.IsPublic,
                Mood = workout.MoodId,
                Name = workout.Name,
                Executed = workout.Executed
            });
        }
    }
}
