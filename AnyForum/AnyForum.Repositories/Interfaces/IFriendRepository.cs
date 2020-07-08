using AnyForum.Data;
using System;
using System.Collections.Generic;

namespace AnyForum.Repositories.Interfaces
{
    public interface IFriendRepository
    {
        void Add(Friend currentUserFriend, Friend otherUserFriend);
        List<Friend> GetAll();
    }
}
