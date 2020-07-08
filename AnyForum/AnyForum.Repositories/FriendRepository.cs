using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyForum.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly AnyForumDbContext context;

        public FriendRepository(AnyForumDbContext context)
        {
            this.context = context;
        }

        public void Add(Friend currentUserFriend, Friend otherUserFriend)
        {
            context.Friends.Add(currentUserFriend);
            context.SaveChanges();
            context.Friends.Add(otherUserFriend);
            context.SaveChanges();
        }

        public List<Friend> GetAll()
        {
            return context.Friends.ToList();
        }

        public List<Friend> GetAll(string userId)
        {
            return context.Friends.Where(x => x.UserId == userId).ToList();
        }
    }
}
