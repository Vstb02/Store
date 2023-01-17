namespace Store.Application.Models.Contacts
{
    public record class ContactDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Patronymic { get; init; }
        public string PhoneNumber { get; init; }
    }
}
