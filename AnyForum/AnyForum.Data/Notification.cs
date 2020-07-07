using AnyForum.Data.Migrations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnyForum.Data
{
    public class Notification
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        [Required]
        public string SendTo { get; set; }
    }
}
