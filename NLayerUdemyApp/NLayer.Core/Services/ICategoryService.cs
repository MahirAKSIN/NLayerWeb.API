﻿using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<CategoryEntity>
    {
        public Task<CustomResposeDto<CategoryWithProductDto>> GetSingleCategoryByWithProductAsynv(int CategoryId);

    }
}
