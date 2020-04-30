using FatigueService.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatigueService.Domain.Query
{
    public struct GetFatigueQuery : IRequest<IEnumerable<FatigueDTO>>
    {
    }
}
