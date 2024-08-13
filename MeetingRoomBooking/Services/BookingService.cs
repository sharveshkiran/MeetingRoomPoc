using MeetingRoomBooking.Data;
using MeetingRoomBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MeetingRoom>> GetMeetingRoomsAsync()
        {
            return await _context.MeetingRooms.ToListAsync();
        }

        public async Task CreateBookingAsync(Booking booking)
        {
            _context.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.MeetingRoom)
                .ToListAsync();
        }
        public async Task<Booking> GetBookingRoomByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Bookings.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> DeleteBookingRoomAsync(int id)
        {
            var bookingRoom = await _context.Bookings.FindAsync(id);
            if (bookingRoom != null)
            {
                _context.Bookings.Remove(bookingRoom);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> IsRoomBookedAsync(int meetingRoomId, DateTime startTime, DateTime endTime)
        {
            return await _context.Bookings
                .AnyAsync(b => b.MeetingRoomId == meetingRoomId &&
                               ((startTime >= b.StartTime && startTime < b.EndTime) ||
                                (endTime > b.StartTime && endTime <= b.EndTime) ||
                                (startTime <= b.StartTime && endTime >= b.EndTime)));
        }
    }
}
