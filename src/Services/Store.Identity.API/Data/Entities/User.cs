using Store.Domain.Entities;

namespace Store.Identity.API.Data.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
