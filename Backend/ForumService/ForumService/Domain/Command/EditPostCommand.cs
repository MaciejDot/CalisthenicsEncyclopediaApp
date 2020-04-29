using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumService.Domain.Command
{
    public class EditPostCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
    }
}
