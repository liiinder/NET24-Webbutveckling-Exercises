using API_example;
using API_example.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        // GET: api/<rooms>
        [HttpGet]
        public async Task<IEnumerable<Room>> Get()
        {
            await using var db = new AppDbContext();
            var rooms = await db.Rooms.ToListAsync();

            return rooms;
        }

        // GET api/<rooms>/{id}
        [HttpGet("{id}")]
        public async Task<Room?> Get(Guid id)
        {
            await using var db = new AppDbContext();
            var room = await db.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            return room;
        }

        // GET api/<rooms>/available
        [HttpGet("available")]
        public async Task<IEnumerable<Room>> GetAvailable()
        {
            await using var db = new AppDbContext();
            var result = await db.Rooms.Where(x => x.IsAvailable).ToListAsync();

            return result;
        }

        [HttpPost]
        public async void Post([FromBody] Room value)
        {
            await using var db = new AppDbContext();
            db.Rooms.Add(new Room(value.Type, value.PricePerNight, value.IsAvailable));
            await db.SaveChangesAsync();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Room updated)
        {
            using var db = new AppDbContext();
            var room = db.Rooms.FirstOrDefault(x => x.Id == id);
            if (room is not null)
            {
                room.Id = updated.Id;
                room.Type = updated.Type;
                room.PricePerNight = updated.PricePerNight;
                room.IsAvailable = updated.IsAvailable;
                db.SaveChanges();
            }
        }
    }
}
