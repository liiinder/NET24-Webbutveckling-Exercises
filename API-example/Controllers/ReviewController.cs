using API_example;
using API_example.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        // GET: api/reviews
        [HttpGet]
        public async Task<IEnumerable<Review>> Get()
        {
            await using var db = new AppDbContext();
            var reviews = await db.Reviews.ToArrayAsync();

            return reviews;
        }

        // GET api/reviews/{id}
        [HttpGet("{id}")]
        public async Task<Review> Get(Guid id)
        {
            await using var db = new AppDbContext();

            var result = await db.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        // POST api/reviews
        [HttpPost]
        public async void Post([FromBody] Review value)
        {
            await using var db = new AppDbContext();
            db.Reviews.Add(new Review(value.CustomerId, value.Comment, value.Rating));
            await db.SaveChangesAsync();
        }
    }
}
