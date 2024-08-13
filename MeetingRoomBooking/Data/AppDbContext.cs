using Microsoft.EntityFrameworkCore;
using MeetingRoomBooking.Models;
using System.Collections.Generic;

namespace MeetingRoomBooking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MeetingRoom> MeetingRooms { get; set; } 
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
