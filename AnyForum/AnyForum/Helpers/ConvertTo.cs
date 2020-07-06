using AnyForum.Data;
using AnyForum.ViewModels.HomeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.Helpers
{
    public static class ConvertTo
    {
        internal static ApproveForumViewModel ApproveForumViewModel(Forum forum)
        {
            return new ApproveForumViewModel
            {
                Id = forum.Id,
                ForumName = forum.ForumName,
                CreatedBy = forum.CreatedBy,
                Description = forum.Description,
                DateCreated = forum.DateCreated
            };
        }

        internal static HomePageViewModel HomePageViewModel(Forum forum)
        {
            return new HomePageViewModel
            {
                Id = forum.Id,
                ForumTitle = forum.ForumName
            };
        }
    }
}
