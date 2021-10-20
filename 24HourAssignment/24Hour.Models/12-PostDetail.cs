﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class PostDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset PostCreated { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? PostModified { get; set; }
    }
}
