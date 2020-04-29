using ExerciseService.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseService.Domain.Query
{
    public class GetAllExercisesQuery : IRequest<List<ExerciseDTO>>
    {
    }
}
