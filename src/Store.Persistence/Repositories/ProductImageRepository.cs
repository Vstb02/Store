using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class ProductImageRepository : BaseRepository<ProductDbContext, BaseFilter, ProductImage, Guid>,
        IProductImageRepository
    {
        public ProductImageRepository(ProductDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
        }
    }
}
