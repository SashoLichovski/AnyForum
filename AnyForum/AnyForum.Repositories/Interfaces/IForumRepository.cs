using AnyForum.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Repositories.Interfaces
{
    public interface IForumRepository
    {
        void Add(Forum forum);
        List<Forum> GetForApproval();
    }
}
