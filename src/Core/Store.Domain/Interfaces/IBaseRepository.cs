using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IBaseRepository<TContext, TFilter, TModel, TKey>
        where TContext : DbContext
        where TFilter : BaseFilter
        where TModel : BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        Task<TModel> GetById(TKey id, CancellationToken cancellationToken = default);
        Task<TModel> Create(TModel data, CancellationToken cancellationToken = default);
        Task<TModel> Update(TModel data, CancellationToken cancellationToken = default);
        Task Delete(TKey id, CancellationToken cancellationToken = default);
        Task<List<TModel>> GetPageItems(FilterPaging paging,
                                        TFilter filter = null,
                                        CancellationToken cancellationToken = default);
    }
}
