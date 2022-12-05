using Binokool.Services.ProductAPI.Models.Dtos;

namespace Binokool.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        /// <summary>
        /// Создать или обновить продукт
        /// </summary>
        Task<IEnumerable<ProductDto>> GetProducts();
        /// <summary>
        /// Получить продукт
        /// </summary>
        Task<ProductDto> GetProductById(int productId);
        /// <summary>
        /// Получить все продукты
        /// </summary>
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        /// <summary>
        /// Удалить продукт
        /// </summary>
        Task<bool> DeleteProduct (int productId);
    }
}
