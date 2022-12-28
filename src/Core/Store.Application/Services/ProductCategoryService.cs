using SlugGenerator;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _categoryRepository;

        public ProductCategoryService(IProductCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Create(ProductCategory category, CancellationToken cancellationToken)
        {
            var existingEntity = await _categoryRepository.GetByName(category.Name);

            if (existingEntity is not null)
            {
                throw new DuplicateCategoryNameException($"Категория с именем {category.Name} уже существует", existingEntity.Id);
            }

            category.Slug = category.Name.GenerateSlug();

            var result = await _categoryRepository.Create(category, cancellationToken);

            return result.Id;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _categoryRepository.Delete(id, cancellationToken);
        }

        public async Task<IEnumerable<ProductCategory>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAll();

            return result;
        }

        public async Task<ProductCategory> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetById(id, cancellationToken);

            return result;
        }

        public async Task<ProductCategory> Update(ProductCategory category, CancellationToken cancellationToken)
        {
            var existingEntity = await _categoryRepository.GetByName(category.Name);

            if (existingEntity is not null && existingEntity.Id != category.Id)
            {
                throw new DuplicateCategoryNameException($"Категория с именем {category.Name} уже существует", existingEntity.Id);
            }

            category.Slug = category.Name.GenerateSlug();

            var result = await _categoryRepository.Update(category, cancellationToken);

            return result;
        }
    }
}
