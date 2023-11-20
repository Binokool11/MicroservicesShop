using Authorize.Services.IdentityServer;
using Authorize.Services.IdentityServer.DbContext;
using Authorize.Services.IdentityServer.Models;
using Authorize.Services.IdentityServer.Services;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<SecurityStampValidatorOptions>(opt =>
{
    opt.OnRefreshingPrincipal = SecurityStampValidatorCallback.UpdatePrincipal;
});

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
    opt.Password.RequireNonAlphanumeric = false;

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
