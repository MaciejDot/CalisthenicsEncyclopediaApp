﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ArticleService.Domain.Query;
using ArticleService.Helpers;
using ArticleService.Models;
using ArticleService.Domain.Command;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ArticleService.Domain.DTO;

namespace ArticleService.Controllers
{

    [EnableCors]
    [Route("Article")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStringToHtmlHelper _stringToHtmlHelper;

        public ArticleController(IMediator mediator, IStringToHtmlHelper stringToHtmlHelper)
        {
            _mediator = mediator;
            _stringToHtmlHelper = stringToHtmlHelper;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CreateArticleResponse>> Post([FromForm] CreateArticle request, CancellationToken token)
        {
            var fileStreamResult = Request.Form.Files[0].OpenReadStream();
            var fileBytes = new byte[fileStreamResult.Length];
            fileStreamResult.Read(fileBytes, 0, (int)fileStreamResult.Length);
            var requestCommand = new CreateArticleCommand
            {
                AuthorId = User.Claims.Single(x => x.Type == "Id").Value,
                Created = DateTime.UtcNow.ToUniversalTime(),
                Content = _stringToHtmlHelper.GetHtml(request.Content),
                Description = request.Description,
                Title = request.Title,
                Thumbnail = fileBytes
            };
            return new CreateArticleResponse { Article = await _mediator.Send(requestCommand, token) };
        }

        [HttpGet("{page}")]
        [AllowAnonymous]
        public async Task<ActionResult<ArticlesDTO>> Get(int page, CancellationToken token)
        {
            return await _mediator.Send(new GetArticlesQuery { Skip = 20 * page - 20, Take = 20 }, token);
        }

        [HttpGet("{page}/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetArticleDTO>> Get(int page, int id, CancellationToken token)
        {
            return await _mediator.Send(new GetArticleQuery { Id = id }, token);
        }
    }
}