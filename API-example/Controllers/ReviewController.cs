using API_example.Model;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private List<Review> Reviews { get; set; } = new([
            new Review(1, 1, "Stumma sängar", 1.4),
            new Review(2, 2, "Bra mat", 5),
            new Review(3, 3, "Ej parfymfritt", 0),
            new Review(4, 4, "Helt klart prisvärt", 3),
            new Review(5, 5, "Lite för sunkigt för priset", 1.3),
            ]);

        // GET: api/<ReviewController>
        [HttpGet]
        public IEnumerable<Review> Get()
        {
            return Reviews;
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public Review Get(int id)
        {
            var result = Reviews.FirstOrDefault(x => x.Id == id);
            return result;
        }

        // POST api/<ReviewController>
        [HttpPost]
        public void Post([FromBody] Review value)
        {
            Reviews.Add(value);
        }
    }
}
