using AnyForum.Data;
using AnyForum.Repositories;
using AnyForum.Repositories.Interfaces;
using AnyForum.Services;
using AnyForum.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnyForum
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AnyForumDbContext>(options => options.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog = AnyForumDb; Integrated Security = true"));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AnyForumDbContext>();

            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<IForumRepository, ForumRepository>();

            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<IReplyService, ReplyService>();
            services.AddTransient<IReplyRepository, ReplyRepository>();

            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IFriendRepository, FriendRepository>();

            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<INotificationRepository, NotificationRepository>();

            services.AddMvc();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=HomePage}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
