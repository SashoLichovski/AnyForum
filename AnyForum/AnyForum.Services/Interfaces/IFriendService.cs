using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Services.Interfaces
{
    public interface IFriendService
    {
        void Create(string byUserId, string currentUserId);
        bool IsFriendAlready(string userId, string friendId);
    }
}
