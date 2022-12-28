using SlugGenerator;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using System.Data;

namespace Store.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Create(Product product, CancellationToken cancellationToken = default)
        {
            var existingEntity = await _productRepository.GetByName(product.Name);

            if (existingEntity is not null)
            {
                throw new DuplicateProductNameException($"Продукт с именем {product.Name} уже существует", existingEntity.Id);
            }

            product.Slug = product.Name.GenerateSlug();

            var result = await _productRepository.Create(product, cancellationToken);

            return result.Id;
        }

        public async Task<Product> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _productRepository.GetById(id, cancellationToken);

            return result;
        }

        public async Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _productRepository.GetAll(cancellationToken);

            return result;
        }

        public async Task<Product> Update(Product product, CancellationToken cancellationToken = default )
        {
            var result = await _productRepository.Update(product, cancellationToken);

            var existingEntity = await _productRepository.GetByName(product.Name);

            if (existingEntity is not null && existingEntity.Id != result.Id)
            {
                throw new DuplicateProductNameException($"Продукт с именем {product.Name} уже существует", existingEntity.Id);
            }

            return result;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            await _productRepository.Delete(id, cancellationToken);
        }
    }
}
