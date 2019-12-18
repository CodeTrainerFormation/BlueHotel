using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dal;
using DomainModel;

namespace BackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRoomsController : ControllerBase
    {
        private readonly BlueContext _context;

        public BookingRoomsController(BlueContext context)
        {
            _context = context;
        }

        // GET: api/BookingRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingRoom>>> GetBookingRooms()
        {
            return await _context.BookingRooms.ToListAsync();
        }

        // GET: api/BookingRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingRoom>> GetBookingRoom(int id)
        {
            var bookingRoom = await _context.BookingRooms.FindAsync(id);

            if (bookingRoom == null)
            {
                return NotFound();
            }

            return bookingRoom;
        }

        // PUT: api/BookingRooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingRoom(int id, BookingRoom bookingRoom)
        {
            if (id != bookingRoom.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookingRooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BookingRoom>> PostBookingRoom(BookingRoom bookingRoom)
        {
            _context.BookingRooms.Add(bookingRoom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingRoomExists(bookingRoom.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingRoom", new { id = bookingRoom.BookingId }, bookingRoom);
        }

        // DELETE: api/BookingRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingRoom>> DeleteBookingRoom(int id)
        {
            var bookingRoom = await _context.BookingRooms.FindAsync(id);
            if (bookingRoom == null)
            {
                return NotFound();
            }

            _context.BookingRooms.Remove(bookingRoom);
            await _context.SaveChangesAsync();

            return bookingRoom;
        }

        private bool BookingRoomExists(int id)
        {
            return _context.BookingRooms.Any(e => e.BookingId == id);
        }
    }
}
