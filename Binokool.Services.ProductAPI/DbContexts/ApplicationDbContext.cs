using Binokool.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Binokool.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        #region Model
        //protected override void OnModelCreating(ModelBuilder model)
        //{
        //    base.OnModelCreating(model);
        //    model.Entity<Product>().HasData(new Product
        //    {
        //        ImgUrl = "https://musicmarket.by/images/thumbnails/240/240/detailed/1045/gibson-les-paul-tribute-sh-1.jpg",
        //        ProductId = 1,
        //        Description = "Идеальный вариант для домашних посиделок и самообучения",
        //        CategoryName = "Acoustic guitar",
        //        Name = "Gibson-SG",
        //        Price = 1000

        //    },
        //    new Product
        //    {
        //        ImgUrl = "https://musicmarket.by/images/thumbnails/240/240/detailed/1045/gibson-les-paul-custom-w-ebony-fingerboard-gloss-2019-e-1.jpg",
        //        ProductId = 2,
        //        Description = "Выбор профессионального музыканта",
        //        CategoryName = "Acoustic guitar",
        //        Name = "Crafter-SF",
        //        Price = 3000

        //    },
        //    new Product
        //    {
        //        ImgUrl = "https://musicmarket.by/images/thumbnails/240/240/detailed/1024/AD810_SSB_-main-cort.jpg",
        //        ProductId = 3,
        //        Description = "Гитара для продолжающих гитаристов",
        //        CategoryName = "Electric guitar",
        //        Name = "Cort-BF",
        //        Price = 1500

        //    },
        //    new Product
        //    {
        //        ImgUrl = "https://musicmarket.by/images/thumbnails/240/240/detailed/1066/crafter-d-7-n.jpg",
        //        ProductId = 4,
        //        Description = "Прекрасная гитара из красного дерева",
        //        CategoryName = "Electric guitar",
        //        Name = "Sonata-TR",
        //        Price = 1000

        //    });

        //}
        #endregion
    }
}
