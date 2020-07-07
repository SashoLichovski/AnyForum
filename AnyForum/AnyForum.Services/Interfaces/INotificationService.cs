using AnyForum.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Services.Interfaces
{
    public interface INotificationService
    {
        void Create(string email, string userId, string userRequest);
        List<Notification> GetAll(string userId);
    }
}
