using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.Command
{
    public class DeleteMoodCommand : ICommand
    {
        public IEnumerable<MoodDTO> Moods { get; set; }
    }
}
