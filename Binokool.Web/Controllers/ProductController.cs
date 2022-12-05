using Binokool.Web.Models;
using Binokool.Web.Models.ViewModels;
using Binokool.Web.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Binokool.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices productServices;
        private readonly IHttpClientFactory httpClientFactory;

        public ProductController(IProductServices _productServices,IHttpClientFactory _httpClientFactory)
        {
            productServices = _productServices;
            httpClientFactory = _httpClientFactory;
        }

        [Authorize(Roles = $"{StaticDetails.ADMIN}, {StaticDetails.CUSTOMER}")]

        public async Task<IActionResult> GetProducts()
        {
            string? accessToken = await HttpContext.GetTokenAsync(StaticDetails.ACCESS_TOKEN);
            List<ProductDto> productsDto = new List<ProductDto>();
            var response = await productServices.GetAllProductsAsync<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                productsDto = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                return RedirectToAction("ErrorPage", "Error", new MessagesError { Errors = response.ErrorMessages });
            }
            return View(productsDto);
        }

        [HttpGet]
        [Authorize(Roles = StaticDetails.ADMIN)]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.ADMIN)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                string? accessToken = await HttpContext.GetTokenAsync(StaticDetails.ACCESS_TOKEN);
                var response = await productServices.CreatProductAsync<ResponseDto>(productDto, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("GetProducts");
                }
                else
                {
                    return RedirectToAction("ErrorPage", "Error", new MessagesError { Errors = response.ErrorMessages });
                }
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = StaticDetails.ADMIN)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            string? accessToken = await HttpContext.GetTokenAsync(StaticDetails.ACCESS_TOKEN);
            var response = await productServices.GetProductByIdAsync<ResponseDto>(id, accessToken);
            if (response.Result != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return RedirectToAction("ErrorPage", "Error",new MessagesError { Errors = response.ErrorMessages});
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.ADMIN)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(ProductDto productDto)
        {
            string? accessToken = await HttpContext.GetTokenAsync(StaticDetails.ACCESS_TOKEN);
            var response = await productServices.DeleteProductAsync<ResponseDto>(productDto.ProductId, accessToken);
            if (response.IsSuccess)
            {
                return RedirectToAction("GetProducts");
            }
            return RedirectToAction("ErrorPage", "Error", new MessagesError { Errors = response.ErrorMessages });
        }

        [HttpGet]
        [Authorize(Roles = StaticDetails.ADMIN)]
        public async Task<IActionResult> EditProduct(int id)
        {
            string? accessToken = await HttpContext.GetTokenAsync(StaticDetails.ACCESS_TOKEN);
            var response = await productServices.GetProductByIdAsync<ResponseDto>(id, accessToken);
            if (response.Result != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return RedirectToAction("ErrorPage", "Error", new MessagesError { Errors = response.ErrorMessages });
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.ADMIN)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                string? accessToken = await HttpContext.GetTokenAsync(StaticDetails.ACCESS_TOKEN);
                var response = await productServices.UpdateProductAsync<ResponseDto>(productDto, accessToken);
                if (response.Result != null && response.IsSuccess)
                {
                    return RedirectToAction("GetProducts");
                }
                else
                {
                    return RedirectToAction("ErrorPage", "Error", new MessagesError { Errors = response.ErrorMessages });
                }
            }
            return View(productDto);
        }

        public async Task<IActionResult> AboutProduct(int productId)
        {
            ResponseDto response = await productServices.GetProductByIdAsync<ResponseDto>(productId,"");
            if(response.IsSuccess && response.Result != null)
            {
                ProductDto productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                if (productDto != null)
                {
                    ProductViewModel model = new ProductViewModel { Product = productDto };
                    return View(model);
                }
            }
            MessagesError messages = new MessagesError { Errors = response.ErrorMessages };
            return RedirectToAction("ErrorPage", "Error",messages);
        }
    }
}
