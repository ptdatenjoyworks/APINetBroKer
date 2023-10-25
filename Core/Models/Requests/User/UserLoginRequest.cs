using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests.User
{
    public class UserLoginRequest
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
