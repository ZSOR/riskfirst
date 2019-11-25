using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressMicroService.DBContexts;
using AddressMicroService.Models;

namespace AddressMicroService.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _dbContet;

        public AddressRepository(AddressContext dbContext)
        {
            _dbContet = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void DeleteAddress(int id)
        {
            var address = _dbContet.Addresses.Find(id);

            _dbContet.Addresses.Remove(address);

            Save();
        }

        public Address GetAddress(int id)
        {
            return _dbContet.Addresses.Find(id);
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _dbContet.Addresses;
        }

        public void InsertAddress(Address address)
        {
            _dbContet.Addresses.Add(address);

            Save();
        }

        public void Save()
        {
            _dbContet.SaveChanges(); 
        }

        public void UpdateAddress(Address address)
        {
            _dbContet.Entry(address).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            Save();
        }
    }
}
