using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutExecutionService.Domain.DTO
{
    public class ExerciseExecutionDTO
    {
        public int Series { get; set; }
        public int Reps { get; set; }
        public int AdditionalKgs { get; set; }
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public int Break { get; set; }
    }
}
