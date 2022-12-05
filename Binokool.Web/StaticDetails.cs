namespace Binokool.Web
{
    public static class StaticDetails
    {
        public const string COOKIES = "Cookies";
        public const string OIDC = "oidc";
        public const string ADMIN = "Admin";
        public const string CUSTOMER = "Customer";
        public const string ACCESS_TOKEN = "access_token";
        public const string IDENTITY_API_URL = "https://localhost:7171";
        public const string PRODUCT_API_URL = "https://localhost:7234";
        public const int LIFE_TIME_COOKIE = 10;
        public enum ApiType
        {
            GET,POST,PUT,DELETE
        }
    }
}
