using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkoutExecutionService.Domain.Command;
using WorkoutExecutionService.Domain.DTO;
using WorkoutExecutionService.Domain.Query;
using WorkoutExecutionService.Models;

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

        [HttpDelete("{externalId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid externalId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteWorkoutExecutionCommand
            {
                ExternalId = externalId,
                Username = User.Identity.Name
            }, cancellationToken);
            return Ok();
        }

        [HttpPatch("{externalId}")]
        [Authorize]
        public async Task<IActionResult> Patch(Guid externalId, [FromBody] WorkoutExecutionPatchModel model, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateWorkoutExecutionCommand
            {
                ExternalId = externalId,
                Username = User.Identity.Name,
                Description = model.Description,
                FatigueId = model.Fatigue,
                MoodId = model.Mood,
                Name = model.Name,
                IsPublic = model.IsPublic,
                Executed = model.DateOfWorkout,
                Exercises = model.Exercises.Select(x => new ExerciseExecutionDTO
                {
                    ExerciseName = x.Name,
                    ExerciseId = x.ExerciseId,
                    AdditionalKgs = x.AdditionalKgs,
                    Description = x.Description,
                    Break = x.Break,
                    Order = x.Order,
                    Reps = x.Reps,
                    Series = x.Series
                }
                )
            }, cancellationToken

                );
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<WorkoutExecutionIdentificationDTO>> Post([FromBody] WorkoutExecutionPostModel model, CancellationToken cancellationToken)
        {
            return Ok(
                await _mediator.Send(new AddWorkoutExecutionCommand
                {
                    Username = User.Identity.Name,
                    WorkoutName = model.Name,
                    IsPublic = model.IsPublic,
                    MoodId = model.Mood,
                    Description = model.Description,
                    FatigueId = model.Fatigue,
                    Executed = model.DateOfWorkout,
                    Exercises = model.Exercises.Select(x => new ExerciseExecutionDTO
                    {
                        ExerciseName = x.Name,
                        ExerciseId = x.ExerciseId,
                        AdditionalKgs = x.AdditionalKgs,
                        Description = x.Description,
                        Break = x.Break,
                        Order = x.Order,
                        Reps = x.Reps,
                        Series = x.Series
                    }
                )
                },
                cancellationToken
                ));
        }
    }
}
