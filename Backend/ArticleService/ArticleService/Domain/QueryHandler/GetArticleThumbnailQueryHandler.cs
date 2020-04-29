using ArticleService.Domain.DTO;
using ArticleService.Domain.Query;
using ArticleService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace ArticleService.Domain.QueryHandler
{
    public class GetArticleThumbnailQueryHandler : IRequestHandler<GetArticleThumbnailQuery, GetArticleThumbnailDTO>
    {
        private readonly ArticleServiceContext _context;
        public GetArticleThumbnailQueryHandler(ArticleServiceContext context)
        {
            _context = context;
        }
        public async Task<GetArticleThumbnailDTO> Handle(GetArticleThumbnailQuery request, CancellationToken token)
        {
            var thumbnail = await _context.Thumbnails
                .FindAsync(new object[] { request.Id }, token);
            return new GetArticleThumbnailDTO { Content = thumbnail.Content };
        }
    }
}
