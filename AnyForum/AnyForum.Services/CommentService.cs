using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using AnyForum.Services.Interfaces;
using System;

namespace AnyForum.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepo;
        public CommentService(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public void Create(string message, int forumId, string userId, string userName)
        {
            var newComment = new Comment()
            {
                Message = message,
                DateCreated = DateTime.Now,
                ForumId = forumId,
                UserId = userId,
                CreatedBy = userName
            };
            commentRepo.Add(newComment);
        }
    }
}
