using Binokool.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Binokool.Web.Controllers
{
    public class AccountController : Controller
    {
        public AccountController() {}

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            return SignOut(StaticDetails.COOKIES,StaticDetails.OIDC);
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return RedirectToAction("ErrorPage","Error",
                new MessagesError 
                { 
                    Errors = new List<string> { "Access denied - You have requested access to a protected resource" } 
                });
        }
    }
}
