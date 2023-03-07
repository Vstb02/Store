using Store.Domain.Entities;
using System.Text.Json.Serialization;

namespace Store.Domain.Identity
{
    public class Role : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
