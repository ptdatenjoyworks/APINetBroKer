﻿using Microsoft.AspNetCore.Identity;
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

        public ApplicationUser(string? address, DateTime? birthDay, string? fullName, bool isActive, DateTime dateCreated)
        {
            Address = address;
            BirthDay = birthDay;
            FullName = fullName;
            IsActive = isActive;
            DateCreated = dateCreated;
        }

        [MaxLength(255, ErrorMessage = "Maximum length for the full name is 255 characters")]
        public string? Address { get; private set; }
        public DateTime? BirthDay { get; private set; }

        [Required(ErrorMessage = "Full name is required")]
        [MaxLength(255, ErrorMessage = "Maximum length for the full name is 255 characters")]
        public string? FullName { get; set; }

        public bool IsActive { get; private set; } = true;
        public DateTime DateCreated { get; private set; } = DateTime.Now;

        public ICollection<Core.Entities.Contract.Contract>? Contracts { get; private set; }

        public void Update(string? fullName, string email, string? address, DateTime? birthDay, string? phone)
        {
            FullName = fullName;
            Email = email;
            Address = address;
            BirthDay = birthDay;
            PhoneNumber = phone;
        }

        public void Delete()
        {
            IsActive = false;
        }    
    }
}
