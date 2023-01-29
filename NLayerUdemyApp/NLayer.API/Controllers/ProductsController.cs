using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    [ValidateFilterAttribute]
    public class ProductsController : CustomerBaseController
    {

        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IService<ProductEntity> service, IProductService procductService)
        {
            _mapper = mapper;
            _service = procductService;
            
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {

            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDTO>>(products.ToList());
            return CreateActionResult(CustomResposeDto<List<ProductDTO>>.Success(200, productsDtos));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var products = await _service.GetByIdAsync(id);
            var productsDtos = _mapper.Map<ProductDTO>(products);
            return CreateActionResult(CustomResposeDto<ProductDTO>.Success(200, productsDtos));

        }

        [HttpPost()]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {

            var products = await _service.AddAysync(_mapper.Map<ProductEntity>(productDTO));
            var productsDtos = _mapper.Map<ProductDTO>(products);
            return CreateActionResult(CustomResposeDto<ProductDTO>.Success(201, productsDtos));

        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDTO)
        {

            await _service.UpdateAsync(_mapper.Map<ProductEntity>(productDTO));
            return CreateActionResult(CustomResposeDto<NoContentDto>.Success(204));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDtos = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResposeDto<NoContentDto>.Success(204));

        }

    }
}
