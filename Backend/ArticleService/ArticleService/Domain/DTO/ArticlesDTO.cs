using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.Domain.DTO
{
    public class ArticlesDTO
    {
        public IEnumerable<GetArticlesDTO> Articles { get; set; }
        public int AllArticlesCount { get; set; } 
    }
}
