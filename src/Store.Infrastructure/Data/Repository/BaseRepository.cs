using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repository
{
    public abstract class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey>
        where TModel : BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        private readonly ApplicationDbContext _context;

        protected BaseRepository(ApplicationDbContext context)
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
            var entity = await _context.Set<TModel>().FirstOrDefaultAsync(x => x.Equals(id));
            _context.Remove(entity);
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
