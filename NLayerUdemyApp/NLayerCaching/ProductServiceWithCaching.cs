using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCaching
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "productCache";
        private readonly IProductRepository _repository;
        private readonly IMemoryCache _memoryCache;
        private readonly UnitOfWorkscs _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServiceWithCaching(IProductRepository repository, IMemoryCache memoryCache, UnitOfWorkscs unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {

                _memoryCache.Set(CacheProductKey, _repository.GetProductsWithCategory().Result);

            }

        }
        public async Task<ProductEntity> AddAysync(ProductEntity entity)
        {

            await _repository.AddAysync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }
        public async Task<IEnumerable<ProductEntity>> AddRangeAsync(IEnumerable<ProductEntity> entities)
        {

            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }
        public Task<bool> AnyAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ProductEntity>> GetAllAsync()
        {

            return Task.FromResult(_memoryCache.Get<IEnumerable<ProductEntity>>(CacheProductKey));
        }
        public Task<ProductEntity> GetByIdAsync(int id)
        {

            var product = _memoryCache.Get<List<ProductEntity>>(CacheProductKey).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundException($"{typeof(ProductEntity).Name}{id} not found");

            }
            return Task.FromResult(product);
        }
        public Task<CustomResposeDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = _memoryCache.Get<IEnumerable<ProductEntity>>(CacheProductKey);
            var productsWithCategory = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return Task.FromResult(CustomResposeDto<List<ProductWithCategoryDto>>.Success(200, productsWithCategory));

        }
        public async Task RemoveAsync(ProductEntity entity)
        {

            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();


        }
        public async Task RemoveRangeAsync(IEnumerable<ProductEntity> entities)
        {

            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();

        }
        public async Task UpdateAsync(ProductEntity entity)
        {

            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }
        public IQueryable<ProductEntity> Where(Expression<Func<ProductEntity, bool>> expression)
        {
            return _memoryCache.Get<List<ProductEntity>>(CacheProductKey).Where(expression.Compile()).AsQueryable();

        }
        public async Task CacheAllProductsAsync()
        {

            _memoryCache.Set(CacheProductKey, await _repository.GetAll().ToListAsync());

        }

    }
}
