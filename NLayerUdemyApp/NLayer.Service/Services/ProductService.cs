using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<ProductEntity>, IProductService

    {

        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<ProductEntity> repository, IUnitOfWorks unitOfWorks, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWorks)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResposeDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var product = await _productRepository.GetProductsWithCategory();
            var productDto = _mapper.Map<List<ProductWithCategoryDto>> (product);
            return CustomResposeDto<List<ProductWithCategoryDto>>.Success(200, productDto);
        
        }
    }


}
