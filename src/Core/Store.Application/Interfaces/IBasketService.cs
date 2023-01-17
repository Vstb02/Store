using Store.Application.Models.Baskets;

namespace Store.Application.Interfaces
{
    public interface IBasketService
    {
        Task<BasketItemDto> SetQuantity(string buyerId, Guid productId, int quantity, CancellationToken cancellationToken = default);
        Task AddItemToBasket(string buyerId, Guid productId, CancellationToken cancellationToken = default);
        Task DeleteItemFromBasket(string buyerId, Guid productId, CancellationToken cancellationToken = default);
        Task<BasketDto> GetBasketByBuyerId (string buyerId, CancellationToken cancellation = default);
    }
}
