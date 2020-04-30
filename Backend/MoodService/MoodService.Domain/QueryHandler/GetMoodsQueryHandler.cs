using MediatR;
using MoodService.DataAccess.Repositories;
using MoodService.Domain.DTO;
using MoodService.Domain.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoodService.Domain.QueryHandler
{
    public class GetMoodsQueryHandler : IRequestHandler<GetMoodsQuery, IEnumerable<MoodDTO>>
    {
        private readonly IMoodRepository _moodRepository;

        public GetMoodsQueryHandler(IMoodRepository moodRepository)
        {
            _moodRepository = moodRepository;
        }

        public async Task<IEnumerable<MoodDTO>> Handle(GetMoodsQuery request, CancellationToken cancellationToken)
        {
            var moods = await _moodRepository.GetAllAsync();
            return moods.Select(x=> new MoodDTO {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
