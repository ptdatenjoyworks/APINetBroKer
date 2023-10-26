using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser(string fullName, string address)
        {
            FullName = fullName;
            Address = address;
        }
        public ApplicationUser() { }
        public ApplicationUser(int id, string? userName, string? fullName, string email, string? passwordHash, string? address, DateTime? birthDay, string? phone, bool isActive = true)
        {
            Id = id;
            UserName = userName;
            FullName = fullName;
            Email = email;
            Address = address;
            BirthDay = birthDay;
            PhoneNumber = phone;
            EmailConfirmed = true;
            PhoneNumberConfirmed = true;
        }

        [MaxLength(255, ErrorMessage = "Maximum length for the full name is 255 characters")]
        public string? Address { get; set; }
        public DateTime? BirthDay { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MaxLength(255, ErrorMessage = "Maximum length for the full name is 255 characters")]
        public string? FullName { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public ICollection<Core.Entities.Contract.Contract>? Contracts { get; set; }
    }
}
