using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.Query
{
    public struct GetUsersQuery : IQuery<IEnumerable<UserDTO>>
    {
    }
}
