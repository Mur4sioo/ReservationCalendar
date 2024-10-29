using System.ComponentModel.DataAnnotations;

namespace ReservationCalendar.Components
{
    public class ReservationModel
    {
        [Key]
        public int ReservationId { get; set; }
        public int ReservationTrainerId { get; set; }
        public int ReservationUserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationStartTime { get; set; }
        public TimeSpan ReservationEndTime { get; set; }
        public string Status { get; set; } // New column
    }
}
