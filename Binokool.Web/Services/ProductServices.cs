using Binokool.Web.Models;
using Binokool.Web.Services.Interface;

namespace Binokool.Web.Services
{
    public class ProductServices : BaseService, IProductServices
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductServices(IHttpClientFactory _httpClientFactory) : base(_httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }
        public async Task<T> CreatProductAsync<T>(ProductDto productDto, string accessToken) where T : IErrorMessage, new()
        {
            
            return await base.SendAsync<T>(new ApiRequest { apiType = StaticDetails.ApiType.POST, Data = productDto, url = StaticDetails.PRODUCT_API_URL + "/api/products/Post", AccessToken = accessToken });
        } 

        public async Task<T> DeleteProductAsync<T>(int id, string accessToken) where T : IErrorMessage, new()
        {
            return await base.SendAsync<T>(new ApiRequest { apiType = StaticDetails.ApiType.DELETE, url = StaticDetails.PRODUCT_API_URL + "/api/products/Delete/" + id, AccessToken = accessToken });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string accessToken) where T : IErrorMessage, new()
        {
            return await base.SendAsync<T>(new ApiRequest { apiType = StaticDetails.ApiType.GET, url = StaticDetails.PRODUCT_API_URL + "/api/products/Get/" + id, AccessToken = accessToken });
        }

        public async Task<T> GetAllProductsAsync<T>(string accessToken) where T : IErrorMessage, new()
        {
            return await base.SendAsync<T>(new ApiRequest { apiType = StaticDetails.ApiType.GET, url = StaticDetails.PRODUCT_API_URL + "/api/products/Get", AccessToken = accessToken });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string accessToken) where T : IErrorMessage, new()
        {
            return await base.SendAsync<T>(new ApiRequest { apiType = StaticDetails.ApiType.PUT, Data = productDto, url = StaticDetails.PRODUCT_API_URL + "/api/products/Put", AccessToken = accessToken });
        }
    }
}
