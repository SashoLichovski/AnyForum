using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyForum.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnyForum.Controllers
{
    public class FriendController : Controller
    {
        private readonly INotificationService notificationService;
        private readonly UserManager<IdentityUser> userManager;

        public FriendController(INotificationService notificationService, UserManager<IdentityUser> userManager)
        {
            this.notificationService = notificationService;
            this.userManager = userManager;
        }

        public IActionResult AddFriend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFriend(string email)
        {
            var userRequest = User.Identity.Name;
            var dbUser = userManager.FindByEmailAsync(userRequest);
            if (userManager.FindByEmailAsync(email).Result == null)
            {
                return RedirectToAction("ActionMessage", "Home", new { Message = $"User with email {email} does not exist. Please check your spelling" });
            }
            notificationService.Create(email, dbUser.Result.Id, userRequest);
            return RedirectToAction("ActionMessage", "Home", new { Message = $"Friend request successfuly sent" });
        }

        public IActionResult Accept(string byUserId)
        {
            // create two friend instances for both users
            return RedirectToAction();
        }
    }
}
