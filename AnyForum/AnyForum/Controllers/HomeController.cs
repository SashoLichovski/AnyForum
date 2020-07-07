using AnyForum.Helpers;
using AnyForum.Services.Interfaces;
using AnyForum.ViewModels.HomeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public IActionResult HomePage(string searchInput)
        {
            var viewModelList = new List<HomePageViewModel>();
            if (string.IsNullOrEmpty(searchInput))
            {
                ViewData["header"] = "All forums";
                var dbForums = forumService.GetByStatus(true);
                viewModelList = dbForums.Select(x => ConvertTo.HomePageViewModel(x)).ToList();
            }
            else
            {
                ViewData["header"] = $"Search result for '{searchInput}'";
                var dbSearchForums = forumService.GetSearch(searchInput);
                viewModelList = dbSearchForums.Select(x => ConvertTo.HomePageViewModel(x)).ToList();
            }
            return View(viewModelList);

        }

        [Authorize(Roles = "admin")]
        public IActionResult ForumsForApprove()
        {
            var dbForums = forumService.GetByStatus(false);
            var viewModelList = dbForums.Select(x => ConvertTo.ApproveForumViewModel(x)).ToList();
            return View(viewModelList);
        }

        public IActionResult Approve(int id)
        {
            forumService.Approve(id);
            return RedirectToAction("ForumsForApprove");
        }

        public IActionResult Delete(int id)
        {
            forumService.Remove(id);
            return RedirectToAction("ForumsForApprove");
        }

        public IActionResult ActionMessage(ActionMessageViewModel model)
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
                bool isValid = forumService.Validate(model.ForumName);
                if (isValid)
                {
                    var isAdmin = User.IsInRole("admin");
                    var userName = User.Identity.Name;
                    forumService.Create(model.ForumName, model.Description , userName, isAdmin);
                    if (isAdmin)
                    {
                        return RedirectToAction("HomePage");
                    }
                    return RedirectToAction("ActionMessage", new { Message = "Your forum is now sent for approval. Thank you for your contribution" });
                }
                return RedirectToAction("ActionMessage", new { Message = "Forum with similar name already exist. Please use the search input to find this kind of forum." });
            }
            return View(model);
        }
    }
}
