using Authorize.Services.IdentityServer.DbContext;
using Authorize.Services.IdentityServer.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Authorize.Services.IdentityServer.InitDataBase
{
    public class InitDb : IInitDb
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public InitDb(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Init()
        {
            var result = roleManager.FindByNameAsync("Admin").GetAwaiter().GetResult();
            if (result == null)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();
            }
            
            ApplicationUser admin = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@mail.ru",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@MAIL.RU",
                NormalizedUserName = "ADMIN",
                FirstName = "Binokool",
                LastName = "Admin",
                PhoneNumber = "+1319753903"
            };
            ApplicationUser customer = new ApplicationUser
            {
                UserName = "customer",
                Email = "customer@mail.ru",
                EmailConfirmed = true,
                NormalizedEmail = "CUSTOMER@MAIL.RU",
                NormalizedUserName = "CUSTOMER",
                FirstName = "Binokool",
                LastName = "customer",
                PhoneNumber = "+1414353864"
            };

            userManager.CreateAsync(admin,"Admin123*").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
            var temp = userManager.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,admin.FirstName + " " + admin.LastName),
                new Claim(JwtClaimTypes.Email, admin.Email),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.Role,"Admin"),
                new Claim ("idp","local"),
                new Claim(JwtClaimTypes.Subject, Guid.NewGuid().ToString()) //Required parametr
            }).Result;

            userManager.CreateAsync(customer, "Customer123*").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(customer, "Customer").GetAwaiter().GetResult();
            var temp1 = userManager.AddClaimsAsync(customer, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,customer.FirstName),
                new Claim(JwtClaimTypes.Email, customer.Email),
                new Claim(JwtClaimTypes.GivenName, customer.FirstName + " " + customer.LastName),
                new Claim(JwtClaimTypes.Role,"Customer"),
                new Claim ("idp","local"),
                new Claim(JwtClaimTypes.Subject, Guid.NewGuid().ToString()) //Required parametr
            }).Result;






            #region Code for init db
            //TODO: Init DB
            //app.Use(async (context, next) =>
            //{
            //    var init = context.RequestServices.GetRequiredService<IInitDb>();
            //    init.Init();
            //    await next.Invoke();
            //});
            #endregion
        }
    }
}
