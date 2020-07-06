using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.ViewModels.SingleForumModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public List<ReplyViewModel> Replies { get; set; }
    }
}
