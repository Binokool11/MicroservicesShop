using Binokool.Web.Models;
using Binokool.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Binokool.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IProductServices productServices;
        public HomeController(ILogger<HomeController> logger, IProductServices productServices)
        {
            this.logger = logger;
            this.productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            
            List<ProductDto> products = new List<ProductDto>();
            ResponseDto response = await productServices.GetAllProductsAsync<ResponseDto>(string.Empty);
            HomeViewModel model = new HomeViewModel();
            if (response.IsSuccess && response.Result != null)
            {
                products = JsonSerializer.Deserialize<List<ProductDto>>(Convert.ToString(response.Result));
                if (products != null)
                {
                    model = new HomeViewModel { Products = products };
                    return View(model);
                }
            }
            return View(model);
        }

    }
}