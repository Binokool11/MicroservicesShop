using Binokool.Web.Services.Interface;

namespace Binokool.Web.Models
{
    public class ResponseDto : IErrorMessage
    {
        public ResponseDto() { }
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
