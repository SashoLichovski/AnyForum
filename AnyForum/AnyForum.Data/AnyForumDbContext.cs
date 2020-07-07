using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyForum.Data
{
    public class AnyForumDbContext : IdentityDbContext
    {
        public AnyForumDbContext(DbContextOptions<AnyForumDbContext> options) : base(options)
        {
        }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
