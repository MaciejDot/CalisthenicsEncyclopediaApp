using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkoutExecutionService.Domain.DTO;
using WorkoutExecutionService.Domain.Query;

namespace WorkoutExecutionService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<WorkoutExecutionDTO>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetUserWorkoutsQuery { Username = User.Identity.Name }, cancellationToken));
        }

        [HttpGet("{ownerName}/{externalId}")]
        [AllowAnonymous]
        public async Task<ActionResult<WorkoutExecutionDTO>> Get(string ownerName, Guid externalId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetUserWorkoutQuery
            {
                IssuerName = User?.Identity?.Name,
                ExternalId = externalId,
                OwnerName = ownerName
            }, cancellationToken));
        }

    }
}
