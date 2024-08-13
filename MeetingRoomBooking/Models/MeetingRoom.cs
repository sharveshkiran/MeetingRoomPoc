using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBooking.Models
{
    public class MeetingRoom
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}
