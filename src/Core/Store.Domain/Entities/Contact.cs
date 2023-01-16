namespace Store.Domain.Entities
{
    public class Contact : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string BuyerId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
