namespace Binokool.Web.Services.Interface
{
    public interface IErrorMessage
    {
        List<string> ErrorMessages { get; set; }
        bool IsSuccess { get; set; }

    }
}
