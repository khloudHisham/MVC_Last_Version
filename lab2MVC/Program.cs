using lab2MVC.Models;

namespace lab2MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register ITIContext with the dependency injection container
            builder.Services.AddDbContext<ITIContext, ITIContext>();
            //solve  second exception can't open http  unable to resolve services
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            // to solve exception: InvalidOperationException: Session has not been configured for this application or request.

            app.UseSession();
            //////////////////////////////
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
