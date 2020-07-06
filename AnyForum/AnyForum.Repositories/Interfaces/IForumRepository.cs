using AnyForum.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Repositories.Interfaces
{
    public interface IForumRepository
    {
        void Add(Forum forum);
        List<Forum> GetByStatus(bool isApproved);
        Forum GetById(int id);
        void Update(Forum forum);
        void Remove(int id);
        List<Forum> GetAll();
    }
}
