using Binokool.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binokool.Web.Controllers
{
    public class ErrorController : Controller
    {

        public IActionResult ErrorPage(MessagesError Error)
        {
            return View(Error);
        }
    }
}
