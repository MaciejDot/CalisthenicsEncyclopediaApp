using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutExecutionService.Domain.Command
{
    public class DeleteWorkoutExecutionCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public Guid ExternalId { get; set; }
    }
}
