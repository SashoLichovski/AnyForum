using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnyForum.Data
{
    public class Friend
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FriendId { get; set; }
        public List<Chat> Chat { get; set; }
    }
}
