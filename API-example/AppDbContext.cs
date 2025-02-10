using API_example.Model;
using Microsoft.EntityFrameworkCore;

namespace API_example
{
    public class AppDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Employees { get; set; }
        public string DbPath { get; }
        public AppDbContext()
        {
            DbPath = "hotels.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
