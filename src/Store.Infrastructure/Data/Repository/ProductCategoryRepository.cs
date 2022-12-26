using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, Guid>,
        IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
