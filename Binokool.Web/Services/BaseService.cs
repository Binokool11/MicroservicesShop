using Binokool.Web.Models;
using Binokool.Web.Services.Interface;
using Newtonsoft.Json;
using System.Text;

namespace Binokool.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto ResponseModel { get; set; }
        public IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            ResponseModel = new ResponseDto();
            HttpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest) where T : IErrorMessage,new()
        {
            try
            {
                var client = HttpClient.CreateClient("BinokoolAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.Headers.Add("Authorization", $"Bearer {apiRequest.AccessToken}");
                message.RequestUri = new Uri(apiRequest.url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.apiType)
                {
                    case StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                if (apiResponseDto == null)
                {
                    if (apiResponse != null)
                    {
                        throw new Exception($"Status code {apiResponse.StatusCode}");
                    }
                    else
                    {
                        throw new Exception("Bad connection with server");
                    }
                }
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var response = new T { ErrorMessages = new List<string> { Convert.ToString(ex.Message) }, IsSuccess = false };
                return response;
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
