using Microsoft.AspNetCore.Identity;
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
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public bool IsApproved { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }

    }
}
