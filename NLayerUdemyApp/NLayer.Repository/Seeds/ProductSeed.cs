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
    public class ProductSeed : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {


            builder.HasData(
                new ProductEntity { Id = 1, CategoryId = 1, Name = "Kalem-1", Price = 200, CreatedDate = DateTime.Now },
                new ProductEntity
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Kalem-2",
                    Price = 300,
                    CreatedDate = DateTime.Now
                },

                      new ProductEntity
                      {
                          Id = 3,
                          CategoryId = 1,
                          Name = "Kalem-3",
                          Price = 600,
                          CreatedDate = DateTime.Now
                      },
                            new ProductEntity
                            {
                                Id = 4,
                                CategoryId = 2,
                                Name = "Kitap-1",
                                Price = 300,
                                CreatedDate = DateTime.Now
                            },
                                  new ProductEntity
                                  {
                                      Id = 5,
                                      CategoryId = 2,
                                      Name = "Kitap-2",
                                      Price = 300,
                                      CreatedDate = DateTime.Now
                                  }


                );
        }
    }
}
