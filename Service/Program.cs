using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using service.DataBase;

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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "service", Version = "v1" });
            });
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "service v1"));
            }

            app.MapGet("/", async (DataContext db) =>
                await db.Trainers.ToListAsync());
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
