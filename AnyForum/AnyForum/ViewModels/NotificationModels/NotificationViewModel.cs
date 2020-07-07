using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.ViewModels.NotificationModels
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string SentTo { get; set; }
        public string ByUserId { get; set; }
    }
}
