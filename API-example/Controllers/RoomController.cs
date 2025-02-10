using API_example.Model;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private List<Room> Rooms { get; set; } = new([

            new Room(1, "Standard", 200, true),
            new Room(2, "Deluxe", 250, false),
            new Room(3, "Suite", 500, true)
            ]);

        // GET: api/<rooms>
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return Rooms;
        }

        // GET api/<rooms>/{id}
        [HttpGet("{id}")]
        public Room? Get(int id)
        {
            var result = Rooms.FirstOrDefault(x => x.Id == id);
            return result;
        }

        // GET api/<rooms>/available
        [HttpGet("available")]
        public IEnumerable<Room> GetAvailable()
        {
            var result = Rooms.Where(x => x.IsAvailable).ToList();
            return result;
        }

    }
}
