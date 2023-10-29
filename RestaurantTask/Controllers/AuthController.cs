using Microsoft.AspNetCore.Mvc;
using RestaurantTask.DTO;
using RestaurantTask.Services.UserService;

namespace RestaurantTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // /api/auth/registerr
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            return BadRequest("Some Properties Are Not Valid"); // Status Code: 400
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if(result.isSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            return BadRequest("Some Properties Are Not Valid");
        }
    }
}
