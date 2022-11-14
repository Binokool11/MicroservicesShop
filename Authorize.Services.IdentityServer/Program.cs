using Authorize.Services.IdentityServer;
using Authorize.Services.IdentityServer.DbContext;
using Authorize.Services.IdentityServer.Models;
using Authorize.Services.IdentityServer.Services;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
{
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 6;

}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
                .AddInMemoryApiResources(StaticDetails.apiResources())
                .AddInMemoryApiScopes(StaticDetails.apiScopes())
                .AddInMemoryClients(StaticDetails.clients())
                .AddInMemoryIdentityResources(StaticDetails.identityResources())
                .AddDeveloperSigningCredential();

builder.Services.AddTransient<IProfileService, ProfileService>();
var app = builder.Build();


app.UseStaticFiles();

app.UseDefaultFiles();

app.MapDefaultControllerRoute();

app.UseCookiePolicy();

app.UseIdentityServer();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
