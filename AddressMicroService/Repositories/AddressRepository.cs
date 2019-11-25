using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressMicroService.DBContexts;
using AddressMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressMicroService.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _dbContext;

        public AddressRepository(AddressContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async void DeleteAddress(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);

            _dbContext.Addresses.Remove(address);

            await _dbContext.SaveChangesAsync(); 
        }

        public async Task<Address> GetAddress(int id)
        {
            return await _dbContext.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _dbContext.Addresses.ToListAsync();
        }

        public async void InsertAddress(Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
        }

        public async void UpdateAddress(Address address)
        {
            _dbContext.Entry(address).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
