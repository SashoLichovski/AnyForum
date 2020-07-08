using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using AnyForum.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool CheckNotification(string id, string email)
        {
            var dbNots = notificationRepo.GetAll(email);
            if (dbNots.FirstOrDefault(x => x.UserId == id && x.SendTo == email) != null)
            {
                return true;
            }
            return false;
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

        public void Delete(string byUserId, string currentUserEmail)
        {
            notificationRepo.Delete(byUserId, currentUserEmail);
        }

        public void Delete(int id)
        {
            notificationRepo.Delete(id);
        }

        public List<Notification> GetAll(string email)
        {
            return notificationRepo.GetAll(email);
        }
    }
}
