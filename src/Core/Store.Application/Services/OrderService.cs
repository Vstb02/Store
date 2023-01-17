using AutoMapper;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Orders;
using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IContactRepository _contactRepository;

        public OrderService(IOrderRepository orderRepository, IBasketRepository basketRepository, IMapper mapper, IAddressRepository addressRepository, IContactRepository contactRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
        }

        public async Task CreateOrder(Guid addressId,
                                      Guid contactId,
                                      string buyerId,
                                      CancellationToken cancellationToken = default)
        {
            var exsistingBasket = await _basketRepository.GetByBuyerId(buyerId);

            if (exsistingBasket is null)
            {
                throw new NotFoundException("Корзина не найдена");
            }

            var exsistingAddress = await _addressRepository.GetById(addressId, cancellationToken);

            if (exsistingAddress is null)
            {
                throw new NotFoundException("Адрес не найден");
            }

            var exsistingContact = await _contactRepository.GetById(contactId, cancellationToken);

            if (exsistingContact is null)
            {
                throw new NotFoundException("Контакт не найден");
            }

            var basketItems = exsistingBasket.BasketItems;

            var items = _mapper.Map<List<OrderItem>>(basketItems);

            var order = new Order()
            {
                BuyerId = buyerId,
                OrderItems = items,
                AddressId = addressId,
                ContactId = contactId,
                OrderStatus = OrderStatus.inProcessing,
            };

            var result = await _orderRepository.Create(order, cancellationToken);
        }

        public async Task ChangeStatusOrder(Guid orderId,
                                            ChangeOrderDto changeOrder,
                                            CancellationToken cancellationToken = default)
        {
            var existingOrder = await _orderRepository.GetById(orderId);

            if (existingOrder is null)
            {
                throw new NotFoundException("Заказ не найден");
            }

            existingOrder.OrderStatus = changeOrder.OrderStatus;

            await _orderRepository.Update(existingOrder, cancellationToken);
        }
    }
}
