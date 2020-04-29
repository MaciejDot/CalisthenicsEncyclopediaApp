using ArticleService.Domain.DTO;
using ArticleService.Domain.Query;
using ArticleService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleService.Domain.QueryHandler
{
    public class GetArticlesQueryHandler :IRequestHandler<GetArticlesQuery, ArticlesDTO>
    {
        private readonly ArticleServiceContext _context;
        public GetArticlesQueryHandler(ArticleServiceContext context)
        {
            _context = context;
        }
        public async Task<ArticlesDTO> Handle(GetArticlesQuery request, CancellationToken token)
        {
            var articles = await _context
                .Articles
                .OrderByDescending(article => article.Created)
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(article => new GetArticlesDTO
                {
                    Id = article.Id,
                    Author = article.Author.Username,
                    Created = article.Created,
                    Description = article.Description,
                    Title = article.Title,
                    ThumbnailId = article.ThumbnailId
                })
                .ToListAsync(token);
            var articlesCount = await _context.Articles.CountAsync(token);
            return new ArticlesDTO
            {
                Articles = articles,
                AllArticlesCount = articlesCount
            };

        }
    }
}
