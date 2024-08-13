using Microsoft.AspNetCore.Mvc;
using MeetingRoomBooking.Models;
using MeetingRoomBooking.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MeetingRoomBooking.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetBookingsAsync();
            return View(bookings);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create()
        {
            var meetingRooms = await _bookingService.GetMeetingRoomsAsync();
            ViewBag.MeetingRooms = new SelectList(meetingRooms, "Id", "Name");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            var isRoomBooked = await _bookingService.IsRoomBookedAsync(booking.MeetingRoomId, booking.StartTime, booking.EndTime);

            if (isRoomBooked)
            {
                ModelState.AddModelError(string.Empty, "The room is already booked during the selected time slot.");
                var meetingRooms = await _bookingService.GetMeetingRoomsAsync();
                ViewBag.MeetingRooms = new SelectList(meetingRooms, "Id", "Name");
                return View(booking);
            }

            await _bookingService.CreateBookingAsync(booking);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var meetingRoom = await _bookingService.GetBookingRoomByIdAsync(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            return View(meetingRoom);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _bookingService.DeleteBookingRoomAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
