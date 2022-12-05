using System.ComponentModel.DataAnnotations;
namespace Binokool.Services.ProductAPI.Models
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id продукта
        /// </summary>
        [Key]
        public int ProductId {get; set;}
        /// <summary>
        /// Имя продукта
        /// </summary>
        [Required]
        public string Name { get; set;}

        /// <summary>
        /// Цена продукта
        /// </summary>
        [Range(1,1000)]
        public double Price { get; set; }
        /// <summary>
        /// Полное описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Категория товара
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImgUrl { get; set; } 
    }
}
