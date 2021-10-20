using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        [Required]
        public string ReplyText { get; set; }
        [Required]
        public Guid ReplyAuthorId { get; set; }
        // foreign key reference to "Comment" Id
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
    }
}
