using System.ComponentModel.DataAnnotations;

namespace Authorize.Services.IdentityServer.Models
{
    public class ModelUser
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
