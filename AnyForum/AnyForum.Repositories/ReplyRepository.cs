using AnyForum.Data;
using AnyForum.Repositories.Interfaces;

namespace AnyForum.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly AnyForumDbContext context;

        public ReplyRepository(AnyForumDbContext context)
        {
            this.context = context;
        }

        public void Add(Reply reply)
        {
            context.Replies.Add(reply);
            context.SaveChanges();
        }
    }
}
