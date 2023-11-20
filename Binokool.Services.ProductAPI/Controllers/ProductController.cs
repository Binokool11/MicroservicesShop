using Binokool.Services.ProductAPI.AbstractForData;
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
        private DataContext<ProductDto> _productRepostory;
        public ProductController(DataContext<ProductDto> productRepostory)
        {
            _productRepostory = productRepostory;
            response = new ResponseDto();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepostory.GetAllAsync();
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
                ProductDto productDto = await _productRepostory.GetAsync(id);
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
                ProductDto currentProductDto = await _productRepostory.CreateOrUpdateAsync(productDto);
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
                ProductDto currentProductDto = await _productRepostory.CreateOrUpdateAsync(productDto);
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
                bool isSuccess = await _productRepostory.DeleteAsync(id);
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
