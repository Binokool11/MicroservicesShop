using Authorize.Services.IdentityServer.DbContext;
using Authorize.Services.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
{
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequiredLength = 6;

}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});

builder.Services.AddIdentityServer(opt =>
{

});

var app = builder.Build();

app.UseStaticFiles();

app.UseDefaultFiles();

app.MapDefaultControllerRoute();

app.UseCookiePolicy();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
