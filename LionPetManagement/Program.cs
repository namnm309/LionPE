using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using LionPetManagement.Hubs;

namespace LionPetManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSignalR();

            //DI
            builder.Services.AddDbContext<Su25lionDbContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Repo
            builder.Services.AddScoped<LionAccountRepo>();
            builder.Services.AddScoped<LionProfileRepo>(); 

            //Services
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<LionProfileService>(); 

            //Thêm coookie để lưu session và timeout
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapHub<LionHub>("/lionHub");

            app.Run();
        }
    }
}
