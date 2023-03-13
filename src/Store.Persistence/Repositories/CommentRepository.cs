using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Filters.Comments;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class CommentRepository : BaseRepository<CommentDbContext, CommentFilter, Comment, Guid>,
        ICommentRepository
    {
        private readonly CommentDbContext _context; 

        public CommentRepository(CommentDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public override Task<List<Comment>> GetPageItems(FilterPaging paging, CommentFilter filter, CancellationToken cancellationToken = default)
        {
            var query = _context.Comments.AsNoTracking();

            query = ApplyPaging(query, paging);
            query = ApplyFilter(query, filter);

            var data = query.ToListAsync(cancellationToken);
            return data;
        }
    }
}
