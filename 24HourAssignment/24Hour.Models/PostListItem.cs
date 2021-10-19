using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        // List of Comments
        // List of Likes???
        public Guid AuthorId { get; set; }
        public DateTimeOffset PostCreated { get; set; }
        public DateTimeOffset PostModified { get; set; }
    }
}
