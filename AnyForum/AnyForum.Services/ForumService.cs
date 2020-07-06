using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using AnyForum.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Approve(int id)
        {
            var forum = forumRepo.GetById(id);
            forum.IsApproved = true;
            forumRepo.Update(forum);
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

        public Forum GetById(int id)
        {
            return forumRepo.GetById(id);
        }

        public List<Forum> GetByStatus(bool isApproved)
        {
            return forumRepo.GetByStatus(isApproved);
        }

        public List<Forum> GetSearch(string searchInput)
        {
            var dbForums = forumRepo.GetAll();
            return dbForums.Where(x => x.IsApproved == true && x.ForumName.ToLower().Contains(searchInput.ToLower())).ToList();
        }

        public void Remove(int id)
        {
            forumRepo.Remove(id);
        }

        public bool Validate(string forumName)
        {
            var forums = forumRepo.GetAll();
            var forum = forums.FirstOrDefault(x => x.ForumName.Contains(forumName));
            if (forum == null)
            {
                return true;
            }
            return false;
        }
    }
}
