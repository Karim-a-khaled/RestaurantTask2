using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using RestaurantTask.DTO;
using System.Threading.Tasks;

namespace RestaurantTask.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
    }

    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager) { _userManager = userManager; }
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
    }
}