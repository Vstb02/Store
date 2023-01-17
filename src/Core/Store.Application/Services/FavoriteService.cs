using AutoMapper;
using Store.Application.Common.Exceptions;
using Store.Application.Models.Favorites;
using Store.Application.Models.Filters;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Application.Interfaces;

namespace Store.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository,
                               IMapper mapper,
                               IProductRepository productRepository)
        {
            _favoriteRepository = favoriteRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<FavoriteDto> GetPageItems(string buyerId,
                                                              FilterPagingDto paging,
                                                              CancellationToken cancellationToken = default)
        {
            var existingFavorite = await _favoriteRepository.GetByBuyerId(buyerId, cancellationToken);

            if (existingFavorite is null) 
            {
                existingFavorite = await _favoriteRepository.Create(new Favorite { BuyerId = buyerId },
                                                                    cancellationToken);
            }

            var pagingFilter = _mapper.Map<FilterPaging>(paging);

            var favoritePagingProducts = ApplyPaging(existingFavorite.Products, pagingFilter);

            var favoriteItems = _mapper.Map<List<FavoriteItemDto>>(favoritePagingProducts);

            var result = new FavoriteDto
            {
                Items = favoriteItems,
                TotalQuantity = favoriteItems.Count
            };

            return result;
        }

        public async Task<FavoriteItemDto> AddItemToFavorite(string buyerId,
                                                             Guid productId,
                                                             CancellationToken cancellationToken = default)
        {
            var existingFavorite = await _favoriteRepository.GetByBuyerId(buyerId, cancellationToken);

            if (existingFavorite is null)
            {
                existingFavorite = await _favoriteRepository.Create(new Favorite { BuyerId = buyerId },
                                                    cancellationToken);
            }

            var existingFavoriteItem = existingFavorite.Products.FirstOrDefault(x => x.Id.Equals(productId));

            if (existingFavoriteItem is not null)
            {
                throw new DuplicateException("Товар уже добавлен");
            }

            var existingProduct = await _productRepository.GetById(productId,
                                                                   cancellationToken);

            if (existingProduct is null)
            {
                throw new NotFoundException("Товар не найден");
            }

            existingFavorite.Products.Add(existingProduct);

            await _favoriteRepository.Update(existingFavorite);

            var result = _mapper.Map<FavoriteItemDto>(existingProduct);

            return result;
        }

        public async Task RemoveItemToFavorite(string buyerId,
                                               Guid productId,
                                               CancellationToken cancellationToken = default)
        {
            var existingFavorite = await _favoriteRepository.GetByBuyerId(buyerId, cancellationToken);

            if (existingFavorite is null)
            {
                existingFavorite = await _favoriteRepository.Create(new Favorite { BuyerId = buyerId },
                                                    cancellationToken);
            }

            var existingFavoriteItem = existingFavorite.Products.FirstOrDefault(x => x.Id.Equals(productId));

            if (existingFavoriteItem is null)
            {
                throw new NotFoundException("Товар не найден");
            }

            existingFavorite.Products.Remove(existingFavoriteItem);

            await _favoriteRepository.Update(existingFavorite);
        }

        protected List<Product> ApplyPaging(List<Product> source, FilterPaging paging)
        {
            paging ??= new FilterPaging { PageSize = 10 };
            return source
                .Skip(paging.PageNumber * paging.PageSize)
                .Take(paging.PageSize)
                .ToList();
        }
    }
}
