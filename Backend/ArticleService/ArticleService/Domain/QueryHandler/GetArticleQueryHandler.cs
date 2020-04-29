using ArticleService.Domain.Query;
using ArticleService.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleService.Data;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ArticleService.Domain.QueryHandler
{
    public class GetArticleQueryHandler :IRequestHandler<GetArticleQuery, GetArticleDTO >
    {
        private readonly ArticleServiceContext _context;
        public GetArticleQueryHandler(ArticleServiceContext context)
        {
            _context = context;
        }

        public async Task<GetArticleDTO> Handle(GetArticleQuery request, CancellationToken token)
        {
            var _article = await _context
                .Articles
                .Include(article => article.Author)
                .SingleAsync(a => a.Id == request.Id, token);

            return new GetArticleDTO
            {
                Author = _article.Author.Username,
                Created = _article.Created,
                Content = _article.Content,
                Title = _article.Title
            };
        }
    }
}
