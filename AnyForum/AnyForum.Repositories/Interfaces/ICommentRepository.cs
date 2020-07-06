using AnyForum.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
    }
}
