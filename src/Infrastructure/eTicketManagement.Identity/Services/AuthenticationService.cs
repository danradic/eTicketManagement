using eTicketManagement.Application.Contracts.Identity;
using eTicketManagement.Application.Models.Authentication;
using eTicketManagement.Identity.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eTicketManagement.Identity.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.ErrorMessage = $"User with email '{request.Email}' not found.";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                response.ErrorMessage = $"Credentials for '{request.Email}' aren't valid.";
                return response;
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;

            return response;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    StringBuilder errors = new();

                    foreach (var error in result.Errors.ToList())
                    {
                        errors.Append($"{error.Description} ");
                    }

                    throw new Exception($"{errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email } already exists.");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
