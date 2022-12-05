using Binokool.Services.ProductAPI.Models.Dtos;
using Binokool.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Binokool.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        protected ResponseDto response;
        private IProductRepository productRepostory;
        public ProductController(IProductRepository _productRepostory)
        {
            productRepostory = _productRepostory;
            response = new ResponseDto();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await productRepostory.GetProducts();
                response.Result = productDtos;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await productRepostory.GetProductById(id);
                response.Result = productDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto currentProductDto = await productRepostory.CreateUpdateProduct(productDto);
                response.Result = productDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        [Authorize]
        [HttpPut]
        [Route("[action]")]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto currentProductDto = await productRepostory.CreateUpdateProduct(productDto);
                response.Result = productDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await productRepostory.DeleteProduct(id);
                response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }
    }
}
