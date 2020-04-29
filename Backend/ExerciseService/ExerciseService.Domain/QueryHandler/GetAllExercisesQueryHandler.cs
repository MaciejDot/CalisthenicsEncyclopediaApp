using ExerciseService.DataAccessPoint.Repositories;
using ExerciseService.Domain.DTO;
using ExerciseService.Domain.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseService.Domain.QueryHandler
{
    public class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, List<ExerciseDTO>> 
    { 
        private readonly IExerciseRepository _exerciseRepository;
        public GetAllExercisesQueryHandler(IExerciseRepository exerciseRepository) {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<List<ExerciseDTO>> Handle(GetAllExercisesQuery query, CancellationToken cancellationToken) {
            var exercisesFromRepository = await _exerciseRepository.GetAllAsync(cancellationToken);
            return exercisesFromRepository
                .Select(exercise => new ExerciseDTO { Id = exercise.Id, Name = exercise.Name })
                .ToList();
        }
    }
}
