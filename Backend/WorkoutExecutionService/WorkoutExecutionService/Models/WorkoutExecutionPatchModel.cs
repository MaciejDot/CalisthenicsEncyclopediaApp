using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutExecutionService.Models
{
    public class WorkoutExecutionPatchModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int MoodId { get; set; }
        public int FatigueId { get; set; }
        public IEnumerable<ExerciseExecutionModel> Exercises { get; set; }
    }
}
