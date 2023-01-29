using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [ValidateFilterAttribute]

    public class CategoriesController : CustomerBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService )
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryId}")]

        public async  Task<IActionResult> GetSingleCategoryByWithProductAsynv(int categoryId) 
        {

            return  CreateActionResult(await _categoryService.GetSingleCategoryByWithProductAsynv(categoryId));
        
        }
   


    }
}
 