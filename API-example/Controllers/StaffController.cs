using API_example.Model;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private List<Staff> Employees { get; set; } = new([
                new Staff(1, "Berit Berggren", "Chef"),
                new Staff(2, "Bosse Börjesson", "Städare"),
                new Staff(3, "Ruben Koivisto", "Vaktmästare")
            ]);

        // GET: api/<StaffController>
        [HttpGet]
        public IEnumerable<Staff> Get()
        {
            return Employees;
        }

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public Staff? Get(int id)
        {
            return Employees.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<StaffController>
        [HttpPost]
        public void Post([FromBody] Staff value)
        {
            Employees.Add(value);
        }

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Staff value)
        {
            var updateEmployee = Employees.FirstOrDefault(x => x.Id == id);
            updateEmployee.Name = value.Name;
            updateEmployee.Id = value.Id;
            updateEmployee.Position = value.Position;
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employees.RemoveAll(x => x.Id == id);
        }
    }
}
