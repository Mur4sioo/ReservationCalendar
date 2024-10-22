using Microsoft.EntityFrameworkCore;
using ReservationCalendar.Components.Models;

namespace ReservationCalendar.Components.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("BazaDanych"))
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<TrainerModel> Trainers { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
    }
}