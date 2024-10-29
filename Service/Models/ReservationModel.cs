using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public class ReservationModel
    {
        [Key]
        public int ReservationId { get; set; }
        public TrainerModel Trainer { get; set; }
        public int ReservationUserId { get; set; }
        public DateOnly ReservationDate { get; set; }
        public TimeOnly ReservationStartTime { get; set; }
        public TimeOnly ReservationEndTime { get; set; }
        public string Status { get; set; } // New column
    }
}
