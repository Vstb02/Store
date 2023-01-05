using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IBaseRepository<TContext, TModel, TKey>
    {
        Task<TModel> GetById(TKey id, CancellationToken cancellationToken = default);
        Task<TModel> Create(TModel data, CancellationToken cancellationToken = default);
        Task<TModel> Update(TModel data, CancellationToken cancellationToken = default);
        Task Delete(TKey id, CancellationToken cancellationToken = default);
        Task<List<TModel>> GetPageItems(FilterPagingDto paging = null, CancellationToken cancellationToken = default);
    }
}
