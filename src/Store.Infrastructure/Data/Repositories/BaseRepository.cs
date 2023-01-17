using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;

namespace Store.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TContext, TFilter, TModel, TKey> : IBaseRepository<TFilter, TModel, TKey>
        where TContext : DbContext
        where TFilter : BaseFilter
        where TModel : BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        private readonly TContext _context;

        protected BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TModel> Create(TModel data, CancellationToken cancellationToken = default)
        {
            data.Created = DateTime.UtcNow;
            data.Updated = DateTime.UtcNow;
            await _context.Set<TModel>().AddAsync(data, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }

        public async Task Delete(TKey id, CancellationToken cancellationToken = default)
        {
            var entities = _context.Set<TModel>();
            var deleteEntity = await entities.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
            entities.Remove(deleteEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<TModel>> GetPageItems(FilterPaging paging,
                                                             TFilter filter = null,
                                                             CancellationToken cancellationToken = default)
        {
            var query = _context.Set<TModel>().AsNoTracking();
            query = ApplyPaging(query, paging);

            if (filter is not null)
            {
                query = ApplyFilter(query, filter);
            }

            var data = await query.ToListAsync(cancellationToken);
            return data;
        }

        protected virtual IQueryable<TModel> ApplyPaging(IQueryable<TModel> source, FilterPaging paging)
        {
            paging ??= new FilterPaging { PageSize = 10 };
            return source
                .Skip(paging.PageNumber * paging.PageSize)
                .Take(paging.PageSize);
        }

        protected virtual IQueryable<TModel> ApplyFilter(IQueryable<TModel> result, TFilter filter)
        {
            return result;
        }

        public async Task<TModel> GetById(TKey id, CancellationToken cancellationToken = default)
        {
            var data = await _context.Set<TModel>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
            return data;
        }

        public async Task<TModel> Update(TModel data, CancellationToken cancellationToken = default)
        {
            data.Updated = DateTime.UtcNow;
            _context.Update(data);
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
    }
}
