using AutoMapper;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Brands;
using Store.Application.Models.Filters;
using Store.Application.Models.Products;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository,
                            IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(CreateBrandDto brand, CancellationToken cancellationToken = default)
        {
            var existingEntity = await _brandRepository.GetByName(brand.Name);

            if (existingEntity is not null)
            {
                throw new DuplicateException($"Компания с именем {brand.Name} уже существует");
            }

            var entity = _mapper.Map<Brand>(brand);

            var result = await _brandRepository.Create(entity, cancellationToken);

            return result.Id;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            await _brandRepository.Delete(id, cancellationToken);
        }

        public async Task<List<BrandDto>> GetPageItems(FilterPagingDto paging, BaseFilter filter = null, CancellationToken cancellationToken = default)
        {
            var filterPaging = _mapper.Map<FilterPaging>(paging);

            var result = await _brandRepository.GetPageItems(filterPaging, filter, cancellationToken);

            var entity = _mapper.Map<List<BrandDto>>(result);

            return entity;
        }

        public async Task<BrandDto> Update(Guid id, UpdateBrandDto brand, CancellationToken cancellationToken = default)
        {
            var entity = await _brandRepository.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException("Компания не найдена");
            }

            var existingEntity = await _brandRepository.GetByName(brand.Name);

            if (existingEntity is not null && existingEntity.Id != id)
            {
                throw new DuplicateException($"Компания с именем {brand.Name} уже существует");
            }

            _mapper.Map(brand, entity);

            entity.Updated = DateTime.Now;

            var result = await _brandRepository.Update(entity, cancellationToken);

            var updatedEntity = _mapper.Map<BrandDto>(result);

            return updatedEntity;
        }
    }
}
