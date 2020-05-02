using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.Domain.DTO;

namespace WorkoutExecutionService.Domain.Command
{
    public class UpdateWorkoutExecutionCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int MoodId { get; set; }
        public int FatigueId { get; set; }
        public IEnumerable<ExerciseExecutionDTO> Exercises { get; set; }
    }
}
