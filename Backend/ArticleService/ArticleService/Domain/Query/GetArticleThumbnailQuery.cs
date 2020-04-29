﻿using ArticleService.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.Domain.Query
{
    public class GetArticleThumbnailQuery :IRequest<GetArticleThumbnailDTO>
    {
        public int Id;
    }
}
