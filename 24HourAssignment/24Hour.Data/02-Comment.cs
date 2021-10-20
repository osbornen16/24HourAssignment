using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public Guid CommentAuthorId { get; set; }
        //foreign key for post id
        [ForeignKey(nameof(Post))]
        public int Id { get; set; }
        [ForeignKey(nameof(Post))]
        public Guid AuthorId { get; set; }
        public virtual Reply Reply { get; set; }
    }
}
