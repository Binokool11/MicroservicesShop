using Binokool.Web.Services.Interface;
using static Binokool.Web.StaticDetails;

namespace Binokool.Web.Models
{
    public class ApiRequest
    { 
        public ApiType apiType { get; set; } = ApiType.GET;
        public string url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
