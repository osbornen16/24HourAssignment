using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        // virtual list of Comments
        // virtual list of Likes
        [Required]
        public Guid AuthorId { get; set; }
        public DateTimeOffset PostCreated { get; set; }
        public DateTimeOffset PostModified { get; set; }

    }
}
