namespace Binokool.Services.ShoppingCartAPI.Models.Dto
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Id продукта
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Имя продукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена продукта
        /// </summary>
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
