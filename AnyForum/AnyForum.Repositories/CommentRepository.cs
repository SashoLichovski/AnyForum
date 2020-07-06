using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AnyForumDbContext context;

        public CommentRepository(AnyForumDbContext context)
        {
            this.context = context;
        }

        public void Add(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }
    }
}
