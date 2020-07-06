using AnyForum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.ViewModels.SingleForumModels
{
    public class ForumDetailsViewModel
    {
        public int Id { get; set; }
        public string ForumName { get; set; }
        public string CreatedBy { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
