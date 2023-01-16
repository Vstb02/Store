using AutoMapper;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Addresses;
using Store.Domain.Entities;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository,
                              IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressDto> AddAdress(string buyerId,
                                                CreateAddressDto createAddress,
                                                CancellationToken cancellationToken = default)
        {
            var address = _mapper.Map<Address>(createAddress);
            address.BuyerId = buyerId;

            address = await _addressRepository.Create(address);

            var result = _mapper.Map<AddressDto>(address);

            return result;
        }

        public async Task<List<AddressDto>> GetAddressesByBuyerId(string buyerId,
                                                                  CancellationToken cancellationToken = default)
        {
            var existingAddresses = await _addressRepository.GetAddressesByBuyerId(buyerId, cancellationToken);

            var result = _mapper.Map<List<AddressDto>>(existingAddresses);

            return result;
        }

        public async Task<AddressDto> GetAddress(Guid addressId,
                                                 CancellationToken cancellationToken = default)
        {
            var existingAddress = await _addressRepository.GetById(addressId, cancellationToken);

            if (existingAddress is null)
            {
                throw new NotFoundException("Адрес не найден");
            }

            var result = _mapper.Map<AddressDto>(existingAddress);

            return result;
        }

        public async Task<AddressDto> UpdateAddress(Guid addressId,
                                                    UpdateAddressDto updateAddress,
                                                    CancellationToken cancellationToken = default)
        {
            var exsitingAddress = await _addressRepository.GetById(addressId, cancellationToken);

            if (exsitingAddress is null)
            {
                throw new NotFoundException("Адрес не найден");
            }

            exsitingAddress = _mapper.Map<Address>(updateAddress);

            var address = await _addressRepository.Update(exsitingAddress, cancellationToken);

            var result = _mapper.Map<AddressDto>(address);

            return result;
        }
    }
}
