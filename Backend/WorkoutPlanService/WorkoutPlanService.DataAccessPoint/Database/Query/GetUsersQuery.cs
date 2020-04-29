﻿using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutPlanService.DataAccessPoint.DTO;

namespace WorkoutPlanService.DataAccessPoint.Database.Query
{
    public sealed class GetUsersQuery : IQuery<IEnumerable<UserPersistanceDTO>>
    {
    }
}
