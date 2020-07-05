using AnyForum.Helpers;
using AnyForum.Services.Interfaces;
using AnyForum.ViewModels.HomeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AnyForum.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IForumService forumService;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(IForumService forumService, UserManager<IdentityUser> userManager)
        {
            this.forumService = forumService;
            this.userManager = userManager;
        }

        public IActionResult HomePage()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Approve()
        {
            var dbForums = forumService.GetForApproval();
            var viewModelList = dbForums.Select(x => x.ToViewModel()).ToList();
            return View(viewModelList);
        }

        public IActionResult Success(SuccessViewModel model)
        {
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateForumViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = userManager.GetUserId(User);
                var userName = User.Identity.Name;
                var isAdmin = User.IsInRole("admin");
                forumService.Create(model.ForumName, model.Description ,userId, userName, isAdmin);
                if (isAdmin)
                {
                    return RedirectToAction("HomePage");
                }
                return RedirectToAction("Success", new { Message = "Your forum is now sent for approval. Thank you for your contribution" });
            }
            return View(model);
        }
    }
}
