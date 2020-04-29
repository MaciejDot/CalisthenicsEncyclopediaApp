using ForumService.Data;
using ForumService.Domain.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ForumService.Domain.CommandHandler
{
    public class EditPostCommandHandler : IRequestHandler<EditPostCommand, Unit>
    {
        private readonly ForumServiceContext _context;
        public EditPostCommandHandler(ForumServiceContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditPostCommand command, CancellationToken token) {
            var post = await _context.Posts.FindAsync(new object[] { command.PostId }, token);
            if(post.AuthorId != command.AuthorId)
            {
                throw new Exception("Unauthorized");
            }
            post.Answear = command.Content;
            post.Edited = DateTime.Now;
            await _context.SaveChangesAsync(token);
            return new Unit();
        }
    }
}
