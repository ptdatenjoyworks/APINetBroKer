using AutoMapper;
using Core.Models.Requests.User;
using Core.Services;
using Core.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings settings;
        private readonly UserManager<Core.Entities.User.ApplicationUser> userManager;
        private readonly IMapper mapper;

        public AuthenticationService(UserManager<Core.Entities.User.ApplicationUser> userManager, AppSettings settings, IMapper mapper)
        {
            this.userManager = userManager;
            this.settings = settings;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterRequest userRegisterRequest)
        {
            var user = mapper.Map<Core.Entities.User.ApplicationUser>(userRegisterRequest);
            var result = await userManager.CreateAsync(user, userRegisterRequest.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(user, userRegisterRequest.Roles);
            }
            return result;
        }

        public async Task<Core.Entities.User.ApplicationUser?> Autheticate(UserLoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            var result = user != null && await userManager.CheckPasswordAsync(user, request.Password);
            return result ? user : null;
        }

        public async Task<string> CreateToken(Core.Entities.User.ApplicationUser user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(settings?.Auth?.SecretKey);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(Core.Entities.User.ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
            (
                issuer: settings?.Auth?.ValidIssuer,
                audience: settings?.Auth?.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(settings?.Auth?.Expires)),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings?.Auth?.SecretKey ?? "")),
                    ValidateLifetime = true,
                    ValidIssuer = settings?.Auth?.ValidIssuer,
                    ValidAudience = settings?.Auth?.ValidAudience
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
