using AutoMapper;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Addresses;
using Store.Application.Models.Contacts;
using Store.Domain.Entities;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository,
                              IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactDto> AddContact(string buyerId,
                                                CreateContactDto createContact,
                                                CancellationToken cancellationToken = default)
        {
            var contact = _mapper.Map<Contact>(createContact);
            contact.BuyerId = buyerId;

            contact = await _contactRepository.Create(contact, cancellationToken);

            var result = _mapper.Map<ContactDto>(contact);

            return result;
        }

        public async Task<List<ContactDto>> GetContactsByBuyerId(string buyerId,
                                                                  CancellationToken cancellationToken = default)
        {
            var existingContacts = await _contactRepository.GetContactsByBuyerId(buyerId, cancellationToken);

            var result = _mapper.Map<List<ContactDto>>(existingContacts);

            return result;
        }

        public async Task<ContactDto> UpdateContact(Guid contactId,
                                                    UpdateContactDto updateContact,
                                                    CancellationToken cancellationToken = default)
        {
            var exsitingContact = await _contactRepository.GetById(contactId, cancellationToken);

            if (exsitingContact is null)
            {
                throw new NotFoundException("Контакт не найден");
            }

            exsitingContact = _mapper.Map<Contact>(updateContact);

            var contact = await _contactRepository.Update(exsitingContact, cancellationToken);

            var result = _mapper.Map<ContactDto>(contact);

            return result;
        }

        public async Task<ContactDto> GetContact(Guid contactId,
                                                 CancellationToken cancellationToken = default)
        {
            var exstingContact = await _contactRepository.GetById(contactId, cancellationToken);

            if (exstingContact  is null)
            {
                throw new NotFoundException("Контакт не найден");
            }

            var result = _mapper.Map<ContactDto>(exstingContact);

            return result;
        }
    }
}
