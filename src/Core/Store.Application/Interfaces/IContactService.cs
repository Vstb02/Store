using Store.Application.Models.Addresses;
using Store.Application.Models.Contacts;

namespace Store.Application.Interfaces
{
    public interface IContactService
    {
        Task<ContactDto> AddContact(string buyerId,
                           CreateContactDto createContact,
                           CancellationToken cancellationToken = default);

        Task<ContactDto> UpdateContact(Guid contactId,
                                       UpdateContactDto updateContact,
                                       CancellationToken cancellationToken = default);

        Task<List<ContactDto>> GetContactsByBuyerId(string buyerId,
                                                     CancellationToken cancellationToken = default);

        Task<ContactDto> GetContact(Guid contactId,
                            CancellationToken cancellationToken = default);
    }
}
