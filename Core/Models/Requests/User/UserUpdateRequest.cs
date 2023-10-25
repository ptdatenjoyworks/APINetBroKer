using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests.User
{
    public class UserUpdateRequest
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Maximum length for the full name is 255 characters")]
        public string? FullName { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length for the full name is 255 characters")]
        public string? Address { get; set; }
        public DateTime? BirthDay { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }
    }
}
