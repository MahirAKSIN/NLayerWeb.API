using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<CategoryEntity>
    {

        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {

            builder.HasData(
                new CategoryEntity { Id = 1, Name = "Kalemler" },
                new CategoryEntity { Id = 2, Name = "Kitaplar" },
                new CategoryEntity { Id = 3, Name = "Defterler" });
        }

    }
       
}
