using Core.Entities.User;
using Core.Models.Requests.User;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        Task<ApplicationUser?> Autheticate(UserLoginRequest request);
        Task<IdentityResult> RegisterUser(UserRegisterRequest user);
        Task<string> CreateToken(ApplicationUser user);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
