using Store.Application.Models.Orders;

namespace Store.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(Guid addressId,
                         Guid contactId,
                         string buyerId,
                         CancellationToken cancellationToken = default);

        Task ChangeStatusOrder(Guid orderId,
                               ChangeOrderDto changeOrder,
                               CancellationToken cancellationToken = default);
    }
}
