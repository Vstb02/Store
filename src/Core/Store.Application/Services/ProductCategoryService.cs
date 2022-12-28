using AutoMapper;
using Microsoft.Extensions.Logging;
using SlugGenerator;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Categories;
using Store.Application.Models.Products;
using Store.Domain.Entities;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductCategoryService> _logger;

        public ProductCategoryService(IProductCategoryRepository categoryRepository, ILogger<ProductCategoryService> logger, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Guid> Create(CreateCategoryDto category, CancellationToken cancellationToken = default)
        {
            var existingEntity = await _categoryRepository.GetByName(category.Name);

            if (existingEntity is not null)
            {
                throw new DuplicateCategoryNameException($"Категория с именем {category.Name} уже существует", existingEntity.Id);
            }

            var result = _mapper.Map<ProductCategory>(category);

            result.Slug = category.Name.GenerateSlug();

            var entity = await _categoryRepository.Create(result, cancellationToken);

            return entity.Id;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            await _categoryRepository.Delete(id, cancellationToken);
        }

        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken = default )
        {
            var result = await _categoryRepository.GetAll(cancellationToken);

            var entites = _mapper.Map<List<CategoryDto>>(result);

            return entites;
        }

        public async Task<CategoryDto> GetById(Guid id,
                                                   CancellationToken cancellationToken = default)
        {
            var result = await _categoryRepository.GetById(id, cancellationToken);

            var entity = _mapper.Map<CategoryDto>(result);

            return entity;
        }

        public async Task<CategoryDto> Update(Guid id,
                                              UpdateCategoryDto category,
                                              CancellationToken cancellationToken = default)
        {
            var entity = await _categoryRepository.GetById(id);

            if (entity is null)
            {
                _logger.LogError($"Категория с Id {id} не найдена");
                throw new NotFoundException("Категория не найдена");
            }

            var existingEntity = await _categoryRepository.GetByName(category.Name);

            if (existingEntity is not null && existingEntity.Id != id)
            {
                throw new DuplicateCategoryNameException($"Продукт с именем {category.Name} уже существует", existingEntity.Id);
            }

            _mapper.Map(category, entity);

            entity.Updated = DateTime.Now;

            var result = await _categoryRepository.Update(entity, cancellationToken);

            var updatedEntity = _mapper.Map<CategoryDto>(result);

            return updatedEntity;
        }
    }
}
