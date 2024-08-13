using MeetingRoomBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Services
{
    public interface IBookingService
    {
        Task<List<MeetingRoom>> GetMeetingRoomsAsync();
        Task CreateBookingAsync(Booking booking);
        Task<List<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingRoomByIdAsync(int? id);
        Task<bool> DeleteBookingRoomAsync(int id);
        Task<bool> IsRoomBookedAsync(int meetingRoomId, DateTime startTime, DateTime endTime);
    }
}
