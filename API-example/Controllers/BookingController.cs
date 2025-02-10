using API_example.Model;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private List<Booking> Bookings { get; set; } = new([
            new Booking(1, 1, 2, new DateTime(2025, 10, 10), new DateTime(2025, 10, 15)),
            new Booking(2, 1, 2, new DateTime(2025, 8, 10), new DateTime(2025, 8, 15)),
            new Booking(3, 5, 3, new DateTime(2025, 10, 10), new DateTime(2025, 10, 15)),
            new Booking(4, 2, 1, new DateTime(2025, 10, 10), new DateTime(2025, 10, 15)),
            new Booking(5, 3, 1, new DateTime(2025, 10, 10), new DateTime(2025, 10, 15)),
        ]);

        // GET: api/<BookingsController>
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return Bookings;
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public Booking Get(int id)
        {
            var result = Bookings.FirstOrDefault(x => x.Id == id);
            return result;
        }

        // POST api/<BookingsController>
        [HttpPost]
        public void Post([FromBody] Booking value)
        {
            Bookings.Add(value);
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Booking value)
        {
            var result = Bookings.FirstOrDefault(x => x.Id == id);
            result.Id = value.Id;
            result.CustomerId = value.CustomerId;
            result.RoomId = value.RoomId;
            result.CheckInDate = value.CheckInDate;
            result.CheckOutDate = value.CheckOutDate;
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Bookings.RemoveAll(x => x.Id == id);
        }
    }
}
