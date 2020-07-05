using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.ViewModels.HomeModels
{
    public class ApproveForumViewModel
    {
        public string ForumName { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
