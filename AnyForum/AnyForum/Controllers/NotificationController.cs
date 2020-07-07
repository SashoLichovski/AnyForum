using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyForum.Helpers;
using AnyForum.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnyForum.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService notificationService;
        private readonly UserManager<IdentityUser> userManager;

        public NotificationController(INotificationService notificationService, UserManager<IdentityUser> userManager)
        {
            this.notificationService = notificationService;
            this.userManager = userManager;
        }

        public IActionResult Overview(string email)
        {
            var username = User.Identity.Name;
            var dbNot = notificationService.GetAll(email);
            var modelList = dbNot.Select(x => ConvertTo.NotificationViewModel(x)).ToList();
            return View(modelList);
        }
    }
}
