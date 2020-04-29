using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoodService.Domain.DTO;
using MoodService.Domain.Query;

namespace MoodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoodDTO>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetMoodsQuery(), cancellationToken));
        }
    }
}
