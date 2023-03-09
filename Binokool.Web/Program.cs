using Binokool.Web;
using Binokool.Web.Services;
using Binokool.Web.Services.Interface;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<IProductServices, ProductServices>();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IProductServices,ProductServices>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = StaticDetails.COOKIES;
    opt.DefaultChallengeScheme = StaticDetails.OIDC;
})
                .AddCookie(StaticDetails.COOKIES, opt =>
                {
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(StaticDetails.LIFE_TIME_COOKIE);
                })
                .AddOpenIdConnect(StaticDetails.OIDC, opt =>
                 {
                     opt.ClientId = "binokool";
                     opt.ClientSecret = "binokool_secret";
                     opt.Authority = StaticDetails.IDENTITY_API_URL;
                     opt.SaveTokens = true;
                     opt.ResponseType = "code";
                     opt.TokenValidationParameters.NameClaimType = "name";
                     opt.TokenValidationParameters.RoleClaimType = "role";
                     opt.Scope.Add("binokool");
                     opt.GetClaimsFromUserInfoEndpoint = true;
                     opt.ClaimActions.MapJsonKey("role", "role", "role"); //required for use identity role in asp.net project
                 });

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseRouting();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
