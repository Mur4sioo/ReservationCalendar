using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ReservationCalendar.Components;
using ReservationCalendar.Components.Models;
using ReservationCalendar.Components.Data;
using ReservationCalendar.Migrations;

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

            public async Task<List<ReservationModel>> GetReservationList()
            {
                return await _context.Reservations.ToListAsync();
            }

            public async Task<List<UsersModel>> GetUsersList()
            {
                return await _context.Users.ToListAsync();
            }
            public async Task<List<TrainerAvailabilityModel>> GetTrainerAvailabilityList(int trainerId)
            {
                return await _context.TrainerAvailabilities
                    .Where(x => x.TrainerId == trainerId)
                    .ToListAsync();
            }
            public async Task SaveTrainerAvailability(TrainerAvailabilityModel availability)
            {
                var trainerAvailability = new TrainerAvailabilityModel()
                {
                    TrainerId = availability.TrainerId,
                    AvailabilityDay = availability.AvailabilityDay,
                    StartTime = availability.StartTime,
                    EndTime = availability.EndTime
                };

                _context.TrainerAvailabilities.Add(trainerAvailability);
                await _context.SaveChangesAsync();
            }

            public async Task<string> GetUserName(ReservationModel reservation)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == reservation.ReservationUserId);
                return $"{user.FirstName} {user.LastName} nr. Tel.: {user.PhoneNumber}";
            }
            public async Task<List<TimeSpan>> GetAvailableTimeSlots(int trainerId, DateTime date, TimeSpan sessionDuration)
            {
                var availabilities = await _context.TrainerAvailabilities
                    .Where(a => a.TrainerId == trainerId && a.AvailabilityDay.Date == date.Date)
                    .ToListAsync();
                var reservations = await _context.Reservations
                    .Where(r => r.ReservationTrainerId == trainerId && r.ReservationDate.Date == date.Date)
                    .ToListAsync();

                var availableTimeSlots = new List<TimeSpan>();
                foreach (var availability in availabilities)
                {
                    for (var time = availability.StartTime; time <= availability.EndTime - sessionDuration; time = time.Add(TimeSpan.FromMinutes(30)))
                    {
                        var endTime = time.Add(sessionDuration);
                        if (IsTimeSlotAvailable(time, endTime, reservations))
                        {
                            availableTimeSlots.Add(time);
                        }
                    }
                }

                return availableTimeSlots;
            }
            public async Task<bool> IsTimeSlotAvailable(int trainerId, DateTime date, TimeSpan startTime, TimeSpan endTime)
            {
                var reservations = await _context.Reservations
                    .Where(r => r.ReservationTrainerId == trainerId && r.ReservationDate.Date == date.Date)
                    .ToListAsync();

                return !reservations.Any(r =>
                    (r.ReservationStartTime < endTime && r.ReservationEndTime > startTime) ||
                    (r.ReservationStartTime >= startTime && r.ReservationEndTime <= endTime));
            }
            public async Task UpdateTrainerAvailability(TrainerAvailabilityModel availability)
            {
                var existingAvailability = await _context.TrainerAvailabilities.FindAsync(availability.TrainerId);
                if (existingAvailability != null)
                {
                    existingAvailability.AvailabilityDay = availability.AvailabilityDay;
                    existingAvailability.StartTime = availability.StartTime;
                    existingAvailability.EndTime = availability.EndTime;
                    await _context.SaveChangesAsync();
                }
            }
            public async Task DeleteTrainerAvailability(int availabilityId)
            {
                var availability = await _context.TrainerAvailabilities.FindAsync(availabilityId);
                if (availability != null)
                {
                    _context.TrainerAvailabilities.Remove(availability);
                    await _context.SaveChangesAsync();
                }
            }
            private bool IsTimeSlotAvailable(TimeSpan startTime, TimeSpan endTime, List<ReservationModel> reservations)
            {
                foreach (var reservation in reservations)
                {
                    if ((startTime < reservation.ReservationEndTime && endTime > reservation.ReservationStartTime) ||
                        (startTime < reservation.ReservationStartTime && endTime > reservation.ReservationStartTime) ||
                        (startTime >= reservation.ReservationStartTime && endTime <= reservation.ReservationEndTime))
                    {
                        return false;
                    }
                }
                return true;
            }
            public async Task AddUser(UsersModel user)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            public async Task<UsersModel?> GetUserByPhoneNumber(string phoneNumber)
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            }
            public async Task BookTraining(ReservationModel reservation)
            {
                for (int i = 0; i<3 ;i++)
                {
                    
                }
                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
