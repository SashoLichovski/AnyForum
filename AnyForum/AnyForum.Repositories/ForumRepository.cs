using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
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

        public List<Forum> GetForApproval()
        {
            return context.Forums.Where(x => x.IsApproved == false).ToList();
        }
    }
}
