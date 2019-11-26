using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressMicroService.Models;
using AddressMicroService.Repositories;

namespace AddressMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressesController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException();
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            var addresses = await _addressRepository.GetAddresses();


            return addresses.ToList();
        }
        [HttpGet]
        public async Task<ActionResult<Dictionary<string, Address>>> GetAddressesGroupedByCity()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddressesForCity(string city)
        {
            throw new NotImplementedException();
        }
        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _addressRepository.GetAddress(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public IActionResult PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }
            _addressRepository.UpdateAddress(address);
            

            return NoContent();
        }

        // POST: api/Addresses
        [HttpPost]
        public ActionResult<Address> PostAddress(Address address)
        {
            _addressRepository.InsertAddress(address);
            
            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _addressRepository.DeleteAddress(id);
            return address;
        }
    }
}
