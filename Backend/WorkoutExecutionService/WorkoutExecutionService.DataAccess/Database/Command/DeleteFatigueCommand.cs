using SimpleCQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.Command
{
    public class DeleteFatigueCommand : ICommand
    {
        public IEnumerable<FatigueDTO> Fatigues { get; set; }
    }
}
