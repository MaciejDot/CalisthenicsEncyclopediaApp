using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutExecutionService.DataAccess.Database.Command
{
    public class AddUserCommand : ICommand
    {
        public string Name { get; set; }
    }
}
