using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<CategoryEntity> Categories{ get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductFeatureEntity> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeatureEntity>().HasData(new ProductFeatureEntity()

            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductEntityId = 1

            },
                new ProductFeatureEntity()

                {
                    Id = 2,
                    Color = "Mavi",
                    Height = 100,
                    Width = 200,
                    ProductEntityId = 2

                });




            base.OnModelCreating(modelBuilder);


        }
    }
}
