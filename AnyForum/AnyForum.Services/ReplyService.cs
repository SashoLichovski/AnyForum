using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using AnyForum.Services.Interfaces;
using System;

namespace AnyForum.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository replyRepo;

        public ReplyService(IReplyRepository replyRepo)
        {
            this.replyRepo = replyRepo;
        }

        public void Create(string message, int commentId, string userName)
        {
            var newReply = new Reply()
            {
                Message = message,
                CommentId = commentId,
                CreatedBy = userName,
                DateCreated = DateTime.Now
            };

            replyRepo.Add(newReply);
        }
    }
}
