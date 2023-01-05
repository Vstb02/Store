using AutoMapper;
using Microsoft.Extensions.Logging;
using SlugGenerator;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Categories;
using Store.Application.Models.Products;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using System.Data;

namespace Store.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IMapper mapper,
                              ILogger<ProductService> logger,
                              IProductRepository productRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<Guid> Create(CreateProductDto product,
                                       CancellationToken cancellationToken = default)
        {
            var existingEntity = await _productRepository.GetByName(product.Name);

            if (existingEntity is not null)
            {
                throw new DuplicateProductNameException($"Продукт с именем {product.Name} уже существует", existingEntity.Id);
            }

            var entity = _mapper.Map<Product>(product);

            entity.Slug = entity.Name.GenerateSlug();

            var result = await _productRepository.Create(entity, cancellationToken);

            return result.Id;
        }

        public async Task<ProductDto> GetById(Guid id,
                                              CancellationToken cancellationToken = default)
        {
            var result = await _productRepository.GetById(id, cancellationToken);

            var entity = _mapper.Map<ProductDto>(result);

            return entity;
        }

        public async Task<List<ProductDto>> GetAll(FilterPagingDto paging, CancellationToken cancellationToken = default)
        {
            var result = await _productRepository.GetAll(paging, cancellationToken);

            var entity = _mapper.Map<List<ProductDto>>(result);

            return entity;
        }

        public async Task<ProductDto> Update(Guid id,
                                             UpdateProductDto product,
                                             CancellationToken cancellationToken = default)
        {
            var entity = await _productRepository.GetById(id, cancellationToken);

            if (entity is null)
            {
                _logger.LogError($"Товар с Id {id} не найден");
                throw new NotFoundException("Товар не найдена");
            }

            var existingEntity = await _productRepository.GetByName(product.Name);

            if (existingEntity is not null && existingEntity.Id != id)
            {
                throw new DuplicateProductNameException($"Продукт с именем {product.Name} уже существует", existingEntity.Id);
            }

            _mapper.Map(product, entity);

            entity.Updated = DateTime.Now;

            var result = await _productRepository.Update(entity, cancellationToken);

            var updatedEntity = _mapper.Map<ProductDto>(result);

            return updatedEntity;
        }

        public async Task Delete(Guid id,
                                 CancellationToken cancellationToken = default)
        {
            await _productRepository.Delete(id, cancellationToken);
        }
    }
}
