using AddressMicroService.Models;
using AddressMicroService.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentAssertions;

namespace AddressMicroServiceTests
{
    class EnumerableExtensionTests
    {
        [Test]
        public void GroupByCityFuzzy()
        {
            var addresses = new List<Address>() { new Address
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
                }};

            var result = addresses.GroupByFuzzyString(x => x.City, 3);

            result.Should().ContainKeys("London","New York");
            result["London"].First().Should().BeSameAs(addresses.First());
            result["London"].ElementAt(1).Should().BeSameAs(addresses.ElementAt(1));
            result["New York"].First().Should().BeSameAs(addresses.ElementAt(2));
        } 
    }
}
