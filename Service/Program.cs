using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using service.DataBase;
using Service.Endpoints;
using Service.Models;

namespace Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("BazaDanych");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();

            UsersEndpoints.MapUsersEndpoints(app);
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
