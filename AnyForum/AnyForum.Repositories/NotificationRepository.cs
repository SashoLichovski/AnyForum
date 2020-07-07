using AnyForum.Data;
using AnyForum.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyForum.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AnyForumDbContext context;

        public NotificationRepository(AnyForumDbContext context)
        {
            this.context = context;
        }

        public void Add(Notification notification)
        {
            context.Add(notification);
            context.SaveChanges();
        }

        public List<Notification> GetAll(string email)
        {
            return context.Notifications
                .Include(x => x.User)
                .Where(x => x.SendTo == email)
                .ToList();
        }
    }
}
