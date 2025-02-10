using API_example;
using API_example.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            await using var db = new AppDbContext();
            var customers = await db.Customers.ToListAsync();

            return customers;
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public async Task<Customer?> Get(Guid id)
        {
            await using var db = new AppDbContext();

            var result = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        // POST api/customers
        [HttpPost]
        public async void Post([FromBody] Customer value)
        {
            await using var db = new AppDbContext();

            var newCustomer = new Customer(
                value.Name,
                value.ContactInfo);

            db.Customers.Add(newCustomer);

            db.SaveChanges();
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] Customer value)
        {
            await using var db = new AppDbContext();

            var result = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);

            result.Id = value.Id;
            result.Name = value.Name;
            result.ContactInfo = value.ContactInfo;
            db.SaveChanges();
        }
    }
}
