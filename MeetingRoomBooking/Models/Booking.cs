using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int MeetingRoomId { get; set; }

        [Required]
        public string Booker { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        // Navigation property
        public MeetingRoom MeetingRoom { get; set; }
    }
}
