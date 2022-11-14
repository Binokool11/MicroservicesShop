using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Authorize.Services.IdentityServer
{
    public static class StaticDetails
    {
        public const string ADMIN = "Admin";
        public const string CUSTOMER = "Customer";

        public static IEnumerable<IdentityResource> identityResources() => new List<IdentityResource>
        {
            new IdentityResources.Email(),
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> apiScopes() => new List<ApiScope>
        {
            new ApiScope("ProductAPI"),
            new ApiScope("binokool","Binokool Web")
        };

        public static IEnumerable<ApiResource> apiResources() => new List<ApiResource>
        {
            new ApiResource("ProductAPI")
        };

        public static IEnumerable<Client> clients() => new List<Client>
        {
            new Client
            {
                ClientId = "client_id",
                ClientSecrets = {new Secret("client_secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "ProductAPI" }
            },
            new Client
            {
                ClientId = "binokool",
                ClientSecrets = {new Secret("binokool_secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes= 
                { 
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "binokool"
                },
                RedirectUris = { "https://localhost:7047/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:7047/signout-callback-oidc" },
            }
        };
    }
}
