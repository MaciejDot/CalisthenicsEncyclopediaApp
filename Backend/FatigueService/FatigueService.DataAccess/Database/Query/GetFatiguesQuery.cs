using FatigueService.DataAccess.DTO;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatigueService.DataAccess.Database.Query
{
    public struct GetFatiguesQuery : IQuery<IEnumerable<FatigueDTO>>
    {
    }
}
