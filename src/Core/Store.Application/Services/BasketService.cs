using AutoMapper;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Baskets;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IBasketItemRepository _basketItemRepository;

        public BasketService(IBasketRepository basketRepository,
                             IMapper mapper,
                             IProductRepository productRepository,
                             IBasketItemRepository basketItemRepository)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _productRepository = productRepository;
            _basketItemRepository = basketItemRepository;
        }

        public async Task AddItemToBasket(string buyerId, Guid productId, CancellationToken cancellationToken = default)
        {
            var existingBasket = await _basketRepository.GetByBuyerId(buyerId, cancellationToken);

            if (existingBasket == null)
            {
                throw new NotFoundException("Корзина не найдена");
            }

            var existingBasketItem = existingBasket.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (existingBasketItem is not null)
            {
                throw new DuplicateException("Товар уже добавлен в корзину");
            }

            var existingProduct = await _productRepository.GetById(productId, cancellationToken);

            if (existingProduct == null)
            {
                throw new NotFoundException("Товар не найден");
            }

            if (existingProduct.Status is ProductStatus.OutStock)
            {
                throw new OutOfStockException();
            }

            var basketItem = _mapper.Map<BasketItem>(existingProduct);

            existingProduct.Quantity--;

            if (existingProduct.Quantity == 0)
            {
                existingProduct.Status = ProductStatus.OutStock;
            }

            await _productRepository.Update(existingProduct);

            basketItem.BasketId = existingBasket.Id;
            basketItem.ProductId = existingProduct.Id;
            basketItem.Quantity = 1;

            await _basketItemRepository.Create(basketItem);

            existingBasket.BasketItems.Add(basketItem);

            await _basketRepository.Update(existingBasket, cancellationToken);
        }

        public async Task DeleteItemFromBasket(string buyerId, Guid basketItemId, CancellationToken cancellationToken = default)
        {
            var existingBasketItem = await _basketItemRepository.GetById(basketItemId, cancellationToken);

            if (existingBasketItem == null)
            {
                throw new NotFoundException("Товар не найден");
            }

            await _basketItemRepository.Delete(existingBasketItem.Id, cancellationToken);
        }

        public async Task<BasketDto> GetBasketByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var entity = await _basketRepository.GetByBuyerId(buyerId, cancellationToken);

            if (entity == null)
            {
                entity = await _basketRepository.Create(new Basket { BuyerId = buyerId, 
                                                            BasketItems = new List<BasketItem>() }, 
                                               cancellationToken);
            }

            var basketItems = _mapper.Map<List<BasketItemDto>>(entity.BasketItems);

            var result = new BasketDto()
            {
                Items = basketItems,
                TotalPrice = GetBasketPrice(entity),
                TotalQuantity = entity.BasketItems.Sum(x => x.Quantity),
            };

            return result;
        }

        private decimal GetBasketPrice(Basket basket)
        {
            var items = basket.BasketItems;
            var price = 0m;

            foreach (var item in items)
            {
                price += item.Quantity * item.Product.Price;
            }

            return price;
        }

        public async Task<BasketItemDto> SetQuantity(string buyerId,
                                                     Guid basketItemId,
                                                     int quantity,
                                                     CancellationToken cancellationToken = default)
        {
            if (quantity < 0) { 
                throw new ValidationException("Количество товара не может быть отрицательным"); 
            }

            var existingBasket = await _basketRepository.GetByBuyerId(buyerId, cancellationToken);

            if (existingBasket == null)
            {
                throw new NotFoundException("Корзина не найдена");
            }

            var existingBasketItem = await _basketItemRepository.GetById(basketItemId, cancellationToken);

            if (existingBasketItem == null)
            {
                throw new NotFoundException("Товар не найден");
            }

            if (quantity != existingBasketItem.Quantity)
            {
                existingBasketItem.Quantity = quantity;

                await _basketItemRepository.Update(existingBasketItem);
            }

            var result = _mapper.Map<BasketItemDto>(existingBasketItem);

            return result;
        }
    }
}
