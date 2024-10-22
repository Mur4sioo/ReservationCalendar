using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ReservationCalendar.Components;
using ReservationCalendar.Components.Models;
using ReservationCalendar.Components.Data;
namespace ReservationCalendar.Components.Services
{
    public class Services
    {
        public class CalendarServices
        {
            private readonly DataContext _context;
            public CalendarServices(DataContext context)
            {
                _context = context;
            }

            public async Task<List<TrainerModel>> GetTrainerList()
            {
                return await _context.Trainers.ToListAsync();
            }
        }
    }
}
