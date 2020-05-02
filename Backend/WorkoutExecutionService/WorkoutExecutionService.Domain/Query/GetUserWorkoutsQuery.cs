using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.Domain.Query
{
    public class GetUserWorkoutsQuery : IRequest<IEnumerable<WorkoutExecutionDTO>>
    {
        public string Username { get; set; }
    }
}
