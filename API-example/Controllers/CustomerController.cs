using API_example.Model;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private List<Customer> Customers { get; set; } = new([
            new Customer(1, "Kristoffer Linder", "0702729535"),
            new Customer(2, "Bengt-Åke Linder", "0702910305"),
            new Customer(3, "Irene Linder", "080123015"),
            new Customer(4, "Joakim Linder", "0701239155"),
            new Customer(5, "Martin Andersson", "0708129312"),
            ]);

        // GET: api/<rooms>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return Customers;
        }

        // GET api/<rooms>/{id}
        [HttpGet("{id}")]
        public Customer? Get(int id)
        {
            var result = Customers.FirstOrDefault(x => x.Id == id);
            return result;
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            Customers.Add(customer);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            var result = Customers.FirstOrDefault(x => x.Id == id);
            result.Id = customer.Id;
            result.Name = customer.Name;
            result.ContactInfo = customer.ContactInfo;
        }
    }
}
