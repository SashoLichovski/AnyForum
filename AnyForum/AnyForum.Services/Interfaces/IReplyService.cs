using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Services.Interfaces
{
    public interface IReplyService
    {
        void Create(string message, int commentId, string userName);
    }
}
