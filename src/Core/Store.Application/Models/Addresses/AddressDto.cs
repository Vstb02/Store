using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Models.Addresses
{
    public record AddressDto
    {
        public Guid Id { get; init; }
        public string Country { get; init; }
        public string Region { get; init; }
        public string City { get; init; }
        public string Place { get; init; }
        public string Index { get; init; }
    }
}
