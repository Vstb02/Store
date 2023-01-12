using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repositories
{
    public class ProductImageRepository : BaseRepository<ApplicationDbContext, BaseFilter, ProductImage, Guid>,
        IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
