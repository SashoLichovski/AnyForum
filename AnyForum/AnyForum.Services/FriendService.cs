using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using AnyForum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyForum.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository friendRepo;

        public FriendService(IFriendRepository friendRepo)
        {
            this.friendRepo = friendRepo;
        }

        public List<Friend> GetAll(string userId)
        {
            return friendRepo.GetAll(userId);
        }
        public void Create(string byUserId, string currentUserId)
        {
            var currentUserFriend = new Friend()
            {
                FriendId = byUserId,
                UserId = currentUserId
            };
            var otherUserFriend = new Friend()
            {
                FriendId = currentUserId,
                UserId = byUserId,
            };
            friendRepo.Add(currentUserFriend, otherUserFriend);
        }

        public bool IsFriendAlready(string userId, string friendId)
        {
            var dbFriends = friendRepo.GetAll();
            if (dbFriends.FirstOrDefault(x => x.UserId == userId && x.FriendId == friendId) != null)
            {
                return true;
            }
            return false;
        }
    }
}
