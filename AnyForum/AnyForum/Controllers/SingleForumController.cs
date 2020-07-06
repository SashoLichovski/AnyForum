using AnyForum.Helpers;
using AnyForum.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnyForum.Controllers
{
    [Authorize]
    public class SingleForumController : Controller
    {
        private readonly IForumService forumService;
        private readonly ICommentService commentService;
        private readonly IReplyService replyService;
        private readonly UserManager<IdentityUser> userManager;


        public SingleForumController(IForumService forumService,
            ICommentService commentService,
            UserManager<IdentityUser> userManager,
            IReplyService replyService)
        {
            this.forumService = forumService;
            this.commentService = commentService;
            this.userManager = userManager;
            this.replyService = replyService;
        }

        public IActionResult Details(int id)
        {
            var dbForum = forumService.GetById(id);
            var model = ConvertTo.ForumDetailsViewModel(dbForum);
            return View(model);
        }

        [HttpPost]
        public IActionResult Comment(int forumId, string message)
        {
            var userId = userManager.GetUserId(User);
            var userName = User.Identity.Name;
            commentService.Create(message, forumId, userId, userName);
            return RedirectToAction("Details", new { Id = forumId });
        }

        [HttpPost]
        public IActionResult Reply(int forumId, int commentId, string message)
        {
            var userName = User.Identity.Name;
            replyService.Create(message, commentId, userName);
            return RedirectToAction("Details", new { Id = forumId });
        }
    }
}
