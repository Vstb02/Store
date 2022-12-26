namespace Store.Domain.Interfaces
{
    public interface IBaseRepository<TModel, TKey>
    {
        Task<TModel> GetById(TKey id, CancellationToken cancellationToken = default);
        Task<TModel> Create(TModel data, CancellationToken cancellationToken = default);
        Task<TModel> Update(TModel data, CancellationToken cancellationToken = default);
        Task Delete(TKey id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken = default);
    }
}
