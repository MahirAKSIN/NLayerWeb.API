using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<CategoryEntity>, ICategoryService
    {

        private readonly ICategoryRepositroy _categoryRepositroy;
        private readonly IMapper _mapper;


        public CategoryService(IGenericRepository<CategoryEntity> repository, IUnitOfWorks unitOfWorks, IMapper mapper, ICategoryRepositroy categoryRepositroy) : base(repository, unitOfWorks)
        {
            _mapper = mapper;
            _categoryRepositroy = categoryRepositroy;
        }

  
        public async  Task<CustomResposeDto<CategoryWithProductDto>> GetSingleCategoryByWithProductAsynv(int CategoryId)
        {
            var category = await _categoryRepositroy.GetSingleCategoryByWithProductAsynv(CategoryId);
            var categoryDTO = _mapper.Map<CategoryWithProductDto>(category);
            return CustomResposeDto<CategoryWithProductDto>.Success(200, categoryDTO);
        }
    }
}
