using System.ComponentModel.DataAnnotations;
using ReservationCalendar.Components.Models;

namespace ReservationCalendar.Components
{
    public class TrainerModel
    {
        [Key]
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string TrainerLastName { get; set; }
        public string TrainerPhoneNumber { get; set; }
    }
}
