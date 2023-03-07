using Store.Domain.Entities;

namespace Store.Domain.Identity
{
    public class User : BaseEntity<Guid>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserInfoId { get; set; }
        public UserInfo UserInfos { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
