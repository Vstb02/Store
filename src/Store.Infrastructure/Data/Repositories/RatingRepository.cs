using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.Repositories
{
    public class RatingRepository : BaseRepository<ApplicationDbContext, BaseFilter, Rating, Guid>,
        IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rating>> GetByProductId(Guid productId, CancellationToken cancellationToken = default)
        {
            var result = await _context.Ratings.Where(x => x.ProductId.Equals(productId)).ToListAsync();

            return result;
        }
    }
}
