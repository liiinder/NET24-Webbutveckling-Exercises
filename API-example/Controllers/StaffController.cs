using API_example;
using API_example.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        // GET: api/staff
        [HttpGet]
        public async Task<IEnumerable<Staff>> Get()
        {
            await using var db = new AppDbContext();
            var employees = await db.Employees.ToListAsync();

            return employees;
        }

        // GET api/staff/{id}
        [HttpGet("{id}")]
        public async Task<Staff?> Get(Guid id)
        {
            await using var db = new AppDbContext();
            var staff = await db.Employees.FirstOrDefaultAsync(x => x.Id == id);

            return staff;
        }

        // POST api/staff
        [HttpPost]
        public async void Post([FromBody] Staff value)
        {
            await using var db = new AppDbContext();

            var newEmployee = new Staff(value.Name, value.Position);

            db.Employees.Add(newEmployee);
            db.SaveChanges();
        }

        // PUT api/staff/{id}
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] Staff updated)
        {
            await using var db = new AppDbContext();
            var employee = await db.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee is not null)
            {
                employee.Id = updated.Id;
                employee.Name = updated.Name;
                employee.Position = updated.Position;
                db.SaveChanges();
            }
        }

        // DELETE api/staff/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            await using var db = new AppDbContext();

            var employee = await db.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee is not null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }
    }
}
