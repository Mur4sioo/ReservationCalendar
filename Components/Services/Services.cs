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
            public async Task<List<DateTime>> GetTrainerHoursAvailability(int trainerId)
            {
                var timeAdded = new System.TimeSpan(0, 0, 30, 0);
                var trainer = await _context.Trainers.FindAsync(trainerId);
                var availability = new List<DateTime>();
                var startTime = trainer.StartAvailability.TimeOfDay;
                var endTime = trainer.EndAvailability.TimeOfDay;
                var baseDate = trainer.StartAvailability.Date;
                for (var time = startTime; time <= endTime; time = time.Add(timeAdded))
                {
                    availability.Add(baseDate.Add(time));
                }
                return availability;
            }
        }
    }
}
