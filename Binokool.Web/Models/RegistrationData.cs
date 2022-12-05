using System.ComponentModel.DataAnnotations;

namespace Binokool.Web.Models
{
    public class RegistrationData
    {
        [Required(ErrorMessage = "Поле обязательное к заполнению")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Поле обязательное к заполнению")]
        public string? FirstName { get; set; }
        [Required (ErrorMessage = "Поле обязательное к заполнению")]
        public string? LastName { get; set; }
        [Required (ErrorMessage = "Поле обязательное к заполнению")]
        [EmailAddress (ErrorMessage = "Неверно заданный Email")]
        public string? Email { get; set; }
        [Required (ErrorMessage = "Поле обязательное к заполнению")]
        public string? Password { get; set; }
        [Required (ErrorMessage = "Поле обязательное к заполнению")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string? ConfirmedPassword { get; set; }
    }
}
