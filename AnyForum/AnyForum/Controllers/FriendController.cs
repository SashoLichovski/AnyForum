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
        private readonly IFriendService friendService;

        public FriendController(INotificationService notificationService, UserManager<IdentityUser> userManager, IFriendService friendService)
        {
            this.notificationService = notificationService;
            this.userManager = userManager;
            this.friendService = friendService;
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
            if (notificationService.CheckNotification(dbUser.Result.Id, email))
            {
                return RedirectToAction("ActionMessage", "Home", new { Message = $"You have already sent notification to this user - {email}" });
            }
            if (friendService.IsFriendAlready(dbUser.Result.Id, userManager.FindByEmailAsync(email).Result.Id))
            {
                return RedirectToAction("ActionMessage", "Home", new { Message = $"You are already friend with {email}" });
            }
            notificationService.Create(email, dbUser.Result.Id, userRequest);
            return RedirectToAction("ActionMessage", "Home", new { Message = $"Friend request successfuly sent to {email}" });
        }

        public IActionResult Accept(string byUserId)
        {
            var currentUserId = userManager.GetUserId(User);
            var currentDbUser = userManager.FindByIdAsync(currentUserId);
            if (friendService.IsFriendAlready(currentUserId, byUserId))
            {
                notificationService.Delete(byUserId, currentDbUser.Result.Email);
                return RedirectToAction("ActionMessage", "Home", new { Message = $"You are already friend with {userManager.FindByIdAsync(byUserId).Result.Email}" });
            }
            friendService.Create(byUserId, currentUserId);
            notificationService.Delete(byUserId, currentDbUser.Result.Email);
            return RedirectToAction("ActionMessage", "Home", new { Message = $"Friend request accepted. You are now friends with {userManager.FindByIdAsync(byUserId).Result.Email}" });
        }
    }
}
