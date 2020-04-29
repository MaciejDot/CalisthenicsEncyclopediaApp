using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExerciseService.Domain.DTO;
using ExerciseService.Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseService.Controllers
{
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExerciseController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ExerciseDTO>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllExercisesQuery(), cancellationToken);
        }
    }
}
