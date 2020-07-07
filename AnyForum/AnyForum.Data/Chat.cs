using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Data
{
    public class Chat
    {
        public int Id { get; set; }
        public Friend Friend { get; set; }
        public int FriendId { get; set; }
        public string Message { get; set; }
        public string ByUser { get; set; }
    }
}
