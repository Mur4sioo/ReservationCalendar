using System.ComponentModel.DataAnnotations;

namespace ReservationCalendar.Components.Models
{
    public class TrainerAvailabilityModel
    {
        [Key]
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public DateTime AvailabilityDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
