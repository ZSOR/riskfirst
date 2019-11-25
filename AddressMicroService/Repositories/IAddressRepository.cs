using AddressMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressMicroService.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddress(int id);
        void InsertAddress(Address address);
        void DeleteAddress(int id);
        void UpdateAddress(Address address);
        void Save();

    }
}
