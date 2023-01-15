using Store.Application.Models.Baskets;

namespace Store.Application.Models.Favorites
{
    public class FavoriteDto
    {
        public List<FavoriteItemDto> Items { get; init; }
        public int TotalQuantity { get; init; }
    }
}
