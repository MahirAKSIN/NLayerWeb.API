using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepositroy : IGenericRepository<CategoryEntity>
    {
        Task<CategoryEntity> GetSingleCategoryByWithProductAsynv(int CategoryId);

    }
}
