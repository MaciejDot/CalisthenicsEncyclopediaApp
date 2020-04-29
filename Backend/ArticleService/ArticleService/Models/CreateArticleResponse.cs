using ArticleService.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.Models
{
    public class CreateArticleResponse
    {
        public CreateArticleDTO Article { get; set; }
    }
}
