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
    }
}
