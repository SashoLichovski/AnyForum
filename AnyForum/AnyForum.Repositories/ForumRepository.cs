using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnyForum.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly AnyForumDbContext context;

        public ForumRepository(AnyForumDbContext context)
        {
            this.context = context;
        }

        public void Add(Forum forum)
        {
            context.Forums.Add(forum);
            context.SaveChanges();
        }

        public List<Forum> GetAll()
        {
            return context.Forums.ToList();
        }

        public Forum GetById(int id)
        {
            return context.Forums
                .Include(x => x.Comments)
                .ThenInclude(x => x.Replies)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Forum> GetByStatus(bool IsApproved)
        {
            return context.Forums.Where(x => x.IsApproved == IsApproved).ToList();
        }

        public void Remove(int id)
        {
            context.Forums.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(Forum forum)
        {
            context.Forums.Update(forum);
            context.SaveChanges();
        }
    }
}
