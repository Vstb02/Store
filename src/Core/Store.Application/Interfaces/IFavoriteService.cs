using Store.Application.Models.Favorites;
using Store.Application.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IFavoriteService
    {
        Task<FavoriteDto> GetPageItems(string buyerId,
                                       FilterPagingDto paging,
                                       CancellationToken cancellationToken = default);

        Task<FavoriteItemDto> AddItemToFavorite(string buyerId,
                                                Guid productId,
                                                CancellationToken cancellationToken = default);

        Task RemoveItemToFavorite(string buyerId,
                                  Guid productId,
                                  CancellationToken cancellationToken = default);
    }
}
