using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FatigueService.Domain.DTO;
using FatigueService.Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FatigueService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FatigueController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FatigueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FatigueDTO>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetFatigueQuery(), cancellationToken));
        }
    }
}
