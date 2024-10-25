using Microsoft.EntityFrameworkCore;
using Radzen;
using ReservationCalendar.Components;
using ReservationCalendar.Components.Data;
using ReservationCalendar.Components.Services;

namespace ReservationCalendar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("BazaDanych");

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));
            builder.Services.AddScoped<Services.CalendarServices>();
            builder.Services.AddScoped<OutdatedAvailabilityCleanupService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddRadzenComponents();
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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
