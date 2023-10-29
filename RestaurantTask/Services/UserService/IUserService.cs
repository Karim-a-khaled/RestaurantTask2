using RestaurantTask.DTO;


namespace RestaurantTask.Services.UserService
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
    }
}