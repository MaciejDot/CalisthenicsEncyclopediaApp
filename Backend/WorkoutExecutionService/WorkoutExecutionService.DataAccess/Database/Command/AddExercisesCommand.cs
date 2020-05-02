using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.Command
{
    public class AddExercisesCommand : ICommand
    {
        public IEnumerable<ExerciseDTO> Exercises { get; set; }
    }
}
