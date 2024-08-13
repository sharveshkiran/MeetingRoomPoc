using System.Linq;
using MeetingRoomBooking.Models;

namespace MeetingRoomBooking.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if there are any users in the database.
            if (context.Users.Any())
            {
                return;   // Database has been seeded
            }

            var users = new User[]
            {
                new User { Username = "admin", Password = "adminpass", Role = "Admin" },
                new User { Username = "user", Password = "userpass", Role = "User" }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
