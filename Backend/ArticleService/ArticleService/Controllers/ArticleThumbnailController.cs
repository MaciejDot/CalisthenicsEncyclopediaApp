using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ArticleService.Domain.Query;
using System.Threading;
using Microsoft.AspNetCore.Authorization;

namespace ArticleService.Controllers.Article
{
    [EnableCors]
    [Route("ArticleThumbnail")]
    [ApiController]
    public class ArticleThumbnailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleThumbnailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{thumbnailId}")]
        [AllowAnonymous]
        public async Task<FileContentResult> Get(int thumbnailId, CancellationToken token)
        {
            var thumbnail = await _mediator.Send(new GetArticleThumbnailQuery { Id = thumbnailId }, token);
            return base.File(thumbnail.Content, "application/octet-stream");
        }
    }
}