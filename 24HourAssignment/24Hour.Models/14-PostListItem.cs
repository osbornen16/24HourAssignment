using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Reply> Replies { get; set; }
        public Guid AuthorId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset PostCreated { get; set; }
        public DateTimeOffset PostModified { get; set; }
    }
}
