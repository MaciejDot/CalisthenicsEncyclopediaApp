using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArticleService.Domain.Command;
using ArticleService.Domain.DTO;
using ArticleService.Data;
using MediatR;
using ArticleService.Data.Entities;

namespace ArticleService.Domain.CommandHandler
{
    public class CreateArticleCommandHandler :IRequestHandler<CreateArticleCommand, CreateArticleDTO>
    {
        private readonly ArticleServiceContext _context;
        public CreateArticleCommandHandler(ArticleServiceContext applicationDatabaseContext)
        {
            _context = applicationDatabaseContext;
        }
        public async Task<CreateArticleDTO> Handle(CreateArticleCommand command, CancellationToken token)
        {
            var thumbnail = new Thumbnail { Content = command.Thumbnail };
            await _context.Thumbnails
                .AddAsync(thumbnail, token);
            var article = new Article
            {
                Thumbnail = thumbnail,
                Content = command.Content,
                Author = await _context.Users
                    .FindAsync(new object[] { command.AuthorId }, token),
                Title = command.Title,
                Created = command.Created,
                Description = command.Description
            };
            await _context.Articles
                .AddAsync(article, token);
            await _context.SaveChangesAsync(token);
            return new CreateArticleDTO { ArticleId = article.Id };
        }
    }
}
