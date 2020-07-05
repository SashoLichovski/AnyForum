using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnyForum.Data
{
    public class Forum
    {
        public int Id { get; set; }
        [Required]
        public string ForumName { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
