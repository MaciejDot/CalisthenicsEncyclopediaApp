using MoodService.DataAccess.DTO;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodService.Database.Query
{
    public struct GetMoodsQuery : IQuery<IEnumerable<MoodDTO>>
    {
    }
}
