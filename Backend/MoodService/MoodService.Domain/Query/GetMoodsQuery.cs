using MediatR;
using MoodService.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodService.Domain.Query
{
    public struct GetMoodsQuery : IRequest<IEnumerable<MoodDTO>>
    {
    }
}
