using AnyForum.Data;
using AnyForum.Data.Migrations;
using AnyForum.ViewModels.HomeModels;
using AnyForum.ViewModels.SingleForumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.Helpers
{
    public static class ConvertTo
    {
        //  FOR HOME CONTROLLER
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
                ForumTitle = forum.ForumName,
                DateCreated = forum.DateCreated
            };
        }


        // FOR SINGLE FORUM CONTROLLER
        internal static CommentViewModel CommentViewModel(Comment comment)
        {
            var model = new CommentViewModel
            {
                Id = comment.Id,
                Message = comment.Message,
                CreatedBy = comment.CreatedBy,
                DateCreated = comment.DateCreated,
            };
            if (comment.Replies != null)
            {
                model.Replies = comment.Replies.Select(x => ConvertTo.ReplyViewModel(x)).ToList();
            }
            return model;
        }

        internal static ForumDetailsViewModel ForumDetailsViewModel(Forum forum)
        {
            var model = new ForumDetailsViewModel
            {
                Id = forum.Id,
                ForumName = forum.ForumName,
                CreatedBy = forum.CreatedBy,
            };
            if (forum.Comments != null)
            {
                model.Comments = forum.Comments.Select(x => ConvertTo.CommentViewModel(x)).ToList();
            }
            return model;
        }

        internal static ReplyViewModel ReplyViewModel(Reply reply)
        {
            return new ReplyViewModel
            {
                CreatedBy = reply.CreatedBy,
                Message = reply.Message,
                DateCreated = reply.DateCreated
            };
        }
    }
}
