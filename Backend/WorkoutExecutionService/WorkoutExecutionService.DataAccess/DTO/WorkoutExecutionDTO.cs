using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkoutExecutionService.DataAccess.DTO
{
    public class WorkoutExecutionDTO
    {
        public Guid ExternalId { get; set; }
        [MaxLength(400)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public bool IsPublic { get; set; }
        public int MoodId { get; set; }
        public int FatigueId { get; set; }
        public IEnumerable<ExerciseExecutionDTO> Exercises { get; set; }
    }
}
