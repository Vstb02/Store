using Store.Domain.Entities;
using Store.Domain.Enums;
using System.Text.Json.Serialization;

namespace Store.Domain.Identity
{
    public class UserInfo : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public AccountStatus AccountStatus { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
