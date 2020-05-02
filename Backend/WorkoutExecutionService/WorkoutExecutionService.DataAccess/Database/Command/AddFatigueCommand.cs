using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.Command
{
    public class AddFatigueCommand : ICommand
    {
        public IEnumerable<FatigueDTO> Fatigues { get; set; }
    }
}
