using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Friberg_car_rentals_v2;
using Friberg_car_rentals_v2.Data;
namespace Friberg_car_rentals_v2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

            builder.Services.AddTransient<ICar, CarRepository>();
            builder.Services.AddTransient<ICustomer, CustomerRepository>();
            builder.Services.AddTransient<IAdmin, AdminRepository>();
            builder.Services.AddTransient<IBooking, BookingRepository>();

            //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //Fredriks

            builder.Services.AddSession(options => //Session-cookie
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Add services to the container.
            //builder.Services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    var supportedCultures = new[] { "sv-se", "sv" };
            //    options.SetDefaultCulture(supportedCultures[0])
            //        .AddSupportedCultures(supportedCultures)
            //        .AddSupportedUICultures(supportedCultures);
            //});

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession(); //Session-cookie
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
