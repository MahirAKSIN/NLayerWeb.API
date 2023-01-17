using Microsoft.EntityFrameworkCore;
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
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CategoryEntity> builder)
        {

            builder.HasData(
                new CategoryEntity { Id = 1, Name = "Kalemler" },
                new CategoryEntity { Id = 2, Name = "Kitaplar" },
                new CategoryEntity { Id = 3, Name = "Defterler" });

        }
    }
}
