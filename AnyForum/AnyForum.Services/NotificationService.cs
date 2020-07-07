using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using AnyForum.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationRepo;

        public NotificationService(INotificationRepository notificationRepo, UserManager<IdentityUser> userManager)
        {
            this.notificationRepo = notificationRepo;
        }

        public void Create(string email, string userId, string userRequest)
        {
            var notification = new Notification()
            {
                Message = $"New friend request from {userRequest}",
                UserId = userId,
                SendTo = email
            };
            notificationRepo.Add(notification);
        }

        public List<Notification> GetAll(string email)
        {
            return notificationRepo.GetAll(email);
        }
    }
}
