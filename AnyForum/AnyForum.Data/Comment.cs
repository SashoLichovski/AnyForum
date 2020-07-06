using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnyForum.Data
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public Forum Forum { get; set; }
        [Required]
        public int ForumId { get; set; }

        public IdentityUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string CreatedBy { get; set; }

        public List<Reply> Replies { get; set; }
    }
}
