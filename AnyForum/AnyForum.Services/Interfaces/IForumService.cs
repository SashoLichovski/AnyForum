using AnyForum.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Services.Interfaces
{
    public interface IForumService
    {
        void Create(string forumName, string forumDescription , string userName, bool isAdmin);
        List<Forum> GetByStatus(bool isApproved);
        void Approve(int id);
        void Remove(int id);
        bool Validate(string forumName);
        List<Forum> GetSearch(string searchInput);
        Forum GetById(int id);
    }
}
