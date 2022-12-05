using Binokool.Web.Models;

namespace Binokool.Web.Services.Interface
{
    public interface IProductServices : IBaseService
    {
        Task<T> GetAllProductsAsync<T>(string accessToken) where T : IErrorMessage, new();
        Task<T> GetProductByIdAsync<T>(int id, string accessToken) where T : IErrorMessage, new();

        Task<T> CreatProductAsync<T>(ProductDto productDto, string accessToken) where T : IErrorMessage, new();
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string accessToken) where T : IErrorMessage, new();

        Task<T> DeleteProductAsync<T>(int id, string accessToken) where T : IErrorMessage, new();


    }
}
