using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.ViewModels.HomeModels
{
    public class CreateForumViewModel
    {
        [Required]
        public string ForumName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
