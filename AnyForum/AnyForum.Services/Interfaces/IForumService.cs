using AnyForum.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Services.Interfaces
{
    public interface IForumService
    {
        void Create(string forumName, string forumDescription ,string userId, string userName, bool isAdmin);
        List<Forum> GetForApproval();
    }
}
