using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using RestaurantTask.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTask.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
    }

    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration) 
        { 
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<UserManagerResponse> RegisterUserAsync(RegisterModel model)
        {
            if (model is null)
                throw new NullReferenceException("Register Model Is Null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Passwords Does Not Match",
                    isSuccess = false
                };

            var identityUser = new IdentityUser 
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User Was Created Successfully!",
                    isSuccess = true,
                };
            }
            return new UserManagerResponse
            {
                Message = "User Was Not Created!",
                isSuccess = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There Is No User With That Email Address",
                    isSuccess = false,
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponse
                {
                    Message = "Invalid Password",
                    isSuccess = false,
                };
            var claims = new[]
            {
                new Claim("Email",model.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
               claims: claims,
               expires: DateTime.Now.AddDays(30),
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                isSuccess = true,
                ExpireDate = token.ValidTo
            };



        }
    }

}