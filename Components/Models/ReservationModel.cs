using System.ComponentModel.DataAnnotations;

namespace ReservationCalendar.Components
{
    public class ReservationModel
    {
        [Key]
        public int ReservationId { get; set; }
        public int ReservationTreinerId { get; set; }
        public int ReservationUserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
