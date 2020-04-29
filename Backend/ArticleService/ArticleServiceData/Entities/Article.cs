using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleService.Data.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ThumbnailId { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }

        public virtual User Author { get; set; }
        public virtual Thumbnail Thumbnail { get; set; }
    }
}
