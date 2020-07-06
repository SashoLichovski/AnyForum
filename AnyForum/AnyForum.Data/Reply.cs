using AnyForum.Data.Migrations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnyForum.Data
{
    public class Reply
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public Comment Comment { get; set; }
        [Required]
        public int CommentId { get; set; }

        [Required]
        public string CreatedBy { get; set; }
    }
}
