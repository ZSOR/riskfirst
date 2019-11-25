using AddressMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressMicroService.DBContexts
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id= 1, 
                    FirstName = "John",
                    LastName = "Smith",
                    StreetAddress = "Test St 1",
                    City = "London",
                    Country = "England",
                },
                new Address
                {
                    Id=2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    StreetAddress = "Test St 2",
                    City = "london",
                    Country = "England",
                },
                new Address
                {
                    Id=3,
                    FirstName = "Tim",
                    LastName = "Jones",
                    StreetAddress = "Test St 3",
                    City = "New York",
                    Country = "USA",
                });
        }
    }
}
