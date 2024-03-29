﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>,ICategoryRepositroy
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Task<CategoryEntity> GetSingleAsync(int cat)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryEntity> GetSingleCategoryByWithProductAsynv(int CategoryId)
        {

            return await _context.Categories.Include(x => x.ProductEntities).Where(x => x.Id == CategoryId).SingleOrDefaultAsync();
        }
    }
}
