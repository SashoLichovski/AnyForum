using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using AnyForum.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Services
{
    public class ForumService : IForumService
    {
        private readonly IForumRepository forumRepo;

        public ForumService(IForumRepository forumRepo)
        {
            this.forumRepo = forumRepo;
        }

        public void Create(string forumName, string forumDescription ,string userId, string userName, bool isAdmin)
        {
            var newForum = new Forum()
            {
                ForumName = forumName,
                Description = forumDescription,
                DateCreated = DateTime.Now,
                CreatedBy = userName,
                UserId = userId,
            };
            if (isAdmin)
            {
                newForum.IsApproved = true;
            }
            forumRepo.Add(newForum);
        }

        public List<Forum> GetForApproval()
        {
            return forumRepo.GetForApproval();
        }
    }
}
