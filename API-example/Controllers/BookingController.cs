using API_example;
using API_example.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        // GET: api/bookings
        [HttpGet]
        public async Task<IEnumerable<Booking>> Get()
        {
            await using var db = new AppDbContext();
            var bookings = await db.Bookings.ToListAsync();

            return bookings;
        }

        // GET api/bookings/{id}
        [HttpGet("{id}")]
        public async Task<Booking> Get(Guid id)
        {
            await using var db = new AppDbContext();

            var result = db.Bookings.FirstOrDefault(x => x.Id == id);
            return result;
        }

        // POST api/bookings
        [HttpPost]
        public async void Post([FromBody] Booking value)
        {
            await using var db = new AppDbContext();

            var newBooking = new Booking(
                value.CustomerId,
                value.RoomId,
                value.CheckInDate,
                value.CheckOutDate);

            db.Bookings.Add(newBooking);

            db.SaveChanges();

            //await db.SaveChangesAsync();
            // If we want to return a result we want to run it async to wait for the save
        }

        // PUT api/bookings/{id}
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] Booking value)
        {
            await using var db = new AppDbContext();

            var result = await db.Bookings.FirstOrDefaultAsync(x => x.Id == id);

            result.Id = value.Id;
            result.CustomerId = value.CustomerId;
            result.RoomId = value.RoomId;
            result.CheckInDate = value.CheckInDate;
            result.CheckOutDate = value.CheckOutDate;
            db.SaveChanges();
        }

        // DELETE api/bookings/{id}
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            await using var db = new AppDbContext();

            var bookToRemove = await db.Bookings.FirstOrDefaultAsync(x => x.Id == id);

            if (bookToRemove is not null)
            {
                db.Bookings.Remove(bookToRemove);
                db.SaveChanges();
            }
        }
    }
}
