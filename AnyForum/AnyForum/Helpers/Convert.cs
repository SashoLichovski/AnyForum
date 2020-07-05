using AnyForum.Data;
using AnyForum.ViewModels.HomeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.Helpers
{
    public static class Convert
    {
        internal static ApproveForumViewModel ToViewModel(this Forum forum)
        {
            return new ApproveForumViewModel
            {
                ForumName = forum.ForumName,
                CreatedBy = forum.CreatedBy,
                Description = forum.Description,
                DateCreated = forum.DateCreated
            };
        }
    }
}
