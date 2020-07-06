using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Services.Interfaces
{
    public interface ICommentService
    {
        void Create(string message, int forumId, string userId, string userName);
    }
}
