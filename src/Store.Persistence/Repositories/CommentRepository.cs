using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Filters.Comments;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class CommentRepository : BaseRepository<ApplicationDbContext, CommentFilter, Comment, Guid>,
        ICommentRepository
    {
        private readonly ApplicationDbContext _context; 

        public CommentRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Comment> GetByAuthorId(string authorId, CancellationToken cancellationToken = default)
        {
            var result = await _context.Comments.FirstOrDefaultAsync(x => x.AuthorId.Equals(authorId),
                                                                    cancellationToken);

            return result;
        }

        public override async Task<IEnumerable<Comment>> GetPageItems(FilterPaging paging,
                                                               CommentFilter filter,
                                                               CancellationToken cancellationToken = default)
        {
            var query = _context.Comments.AsNoTracking();

            query = ApplyPaging(query, paging);
            query = ApplyFilter(query, filter);

            var data = await query.ToListAsync(cancellationToken);
            return data;
        }
    }
}
