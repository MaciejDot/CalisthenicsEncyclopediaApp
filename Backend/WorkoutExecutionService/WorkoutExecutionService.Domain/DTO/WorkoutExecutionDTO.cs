using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutExecutionService.Domain.DTO
{
    public class WorkoutExecutionDTO
    {
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Executed { get; set; }
        public bool IsPublic { get; set; }
        public int MoodId { get; set; }
        public int FatigueId { get; set; }
        public IEnumerable<ExerciseExecutionDTO> Exercises { get; set; }
    }
}
