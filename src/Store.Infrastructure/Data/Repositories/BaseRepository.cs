using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TContext, TModel, TKey> : IBaseRepository<TContext, TModel, TKey>
        where TContext : DbContext
        where TModel : BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
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

        public async Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken = default)
        {
            var data = await _context.Set<TModel>().ToListAsync();
            return data;
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
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
