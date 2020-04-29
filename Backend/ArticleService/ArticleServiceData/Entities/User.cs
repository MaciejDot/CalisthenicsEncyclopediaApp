using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleService.Data.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
