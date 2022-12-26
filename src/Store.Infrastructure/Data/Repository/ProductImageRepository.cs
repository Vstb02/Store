using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repository
{
    public class ProductImageRepository : BaseRepository<ProductImage, Guid>,
        IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
