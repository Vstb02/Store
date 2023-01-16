using Store.Application.Models.Addresses;

namespace Store.Application.Interfaces
{
    public interface IAddressService
    {
        Task<AddressDto> AddAdress(string buyerId,
                                   CreateAddressDto createAddress,
                                   CancellationToken cancellationToken = default);

        Task<AddressDto> UpdateAddress(Guid addressId,
                                       UpdateAddressDto updateAddress,
                                       CancellationToken cancellationToken = default);

        Task<List<AddressDto>> GetAddressesByBuyerId(string buyerId,
                                                     CancellationToken cancellationToken = default);

        Task<AddressDto> GetAddress(Guid addressId,
                                    CancellationToken cancellationToken = default);
    }
}
