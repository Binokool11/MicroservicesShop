using Binokool.Web.Models;

namespace Binokool.Web.Services.Interface
{
    public interface IBaseService: IDisposable
    {
        ResponseDto ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest) where T : IErrorMessage,new();
    }
}
