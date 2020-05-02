using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutExecutionService.DataAccess.Database.Command
{
    public class DeleteWorkoutExecutionCommand : ICommand
    {
        public DateTime Created { get; set; }
        public Guid ExternalId { get; set; }
        public string Username { get; set; }
    }
}
