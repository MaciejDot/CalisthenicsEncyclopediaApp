using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleService.Data.Entities
{
    public class Thumbnail
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
