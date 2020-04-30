using FatigueService.DataAccess.Repositories;
using FatigueService.Domain.DTO;
using FatigueService.Domain.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatigueService.Domain.QueryHandler
{
    public class GetFatigueQueryHandler : IRequestHandler<GetFatigueQuery, IEnumerable<FatigueDTO>>
    {
        private readonly IFatiguesRepository _fatiguesRepository;
        public GetFatigueQueryHandler(IFatiguesRepository fatiguesRepository) 
        {
            _fatiguesRepository = fatiguesRepository;
        }

        public async Task<IEnumerable<FatigueDTO>> Handle(GetFatigueQuery request, CancellationToken cancellationToken)
        {
            var fatigues =  await _fatiguesRepository.GetAllAsync();
            return fatigues.Select(x => new FatigueDTO { Id = x.Id, Name = x.Name });
        }
    }
}
