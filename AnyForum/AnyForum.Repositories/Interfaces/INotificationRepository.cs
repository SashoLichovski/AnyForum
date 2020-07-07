using AnyForum.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        void Add(Notification notification);
        List<Notification> GetAll(string email);
    }
}
