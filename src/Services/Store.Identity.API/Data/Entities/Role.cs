using Store.Domain.Entities;

namespace Store.Identity.API.Data.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
