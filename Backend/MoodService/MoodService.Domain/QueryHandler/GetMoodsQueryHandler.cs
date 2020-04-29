using MediatR;
using MoodService.Domain.DTO;
using MoodService.Domain.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoodService.Domain.QueryHandler
{
    public class GetMoodsQueryHandler : IRequestHandler<GetMoodsQuery, IEnumerable<MoodDTO>>
    { 
        public Task<IEnumerable<MoodDTO>> Handle(GetMoodsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
