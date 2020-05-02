using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.Domain.DTO;

namespace WorkoutExecutionService.Domain.Query
{
    public class GetUserWorkoutQuery : IRequest<WorkoutExecutionDTO>
    {
        public Guid ExternalId { get; set; }
        public string IssuerName { get; set; }
        public string OwnerName { get; set; }
    }
}
