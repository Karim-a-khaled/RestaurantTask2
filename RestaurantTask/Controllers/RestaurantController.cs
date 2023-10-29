using Microsoft.AspNetCore.Mvc;
using RestaurantTask.Models.DTOS;
using RestaurantTask.Models;
using RestaurantTask.Services.RestaurantService;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<RestaurantDto>> GetAllRestaurants()
        {
            var restaurant = _restaurantService.GetAllRestaurants();
            return Ok(restaurant);
        }

        [HttpGet("GetById")]
        public ActionResult<RestaurantDto> GetSingle(int id)
        {
            var result = _restaurantService.GetSingleRestaurant(id);
            if (result is null)
                return NotFound("Restaurant Not Found");
            return Ok(result);
        }

        [HttpGet("GetByName")]
        public ActionResult<List<Restaurant>> GetByName(string name)
        {
            var results = _restaurantService.GetRestaurantsByName(name);
            if (results.Count == 0)
                return NotFound("No restaurants found with the specified name");

            return Ok(results);
        }

        [HttpPost]
        public ActionResult<RestaurantDto> Post(RestaurantDto restaurant)
        {
            var result = _restaurantService.AddRestaurant(restaurant);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<RestaurantDto> Update(int id, RestaurantDto restaurantInput)
        {
            var restaurant = _restaurantService.GetSingleRestaurant(id);

            if (restaurant is null)
            {
                return NotFound("Restaurant Not Found");
            }

            restaurant.Name = restaurantInput.Name;
            restaurant.Address = restaurantInput.Address;
            restaurant.PhoneNumber = restaurantInput.PhoneNumber;
            restaurant.OpenTime = restaurantInput.OpenTime;
            restaurant.CloseTime = restaurantInput.CloseTime;

            var result = _restaurantService.UpdateRestaurant(id, restaurant);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<Restaurant> Delete(int id)
        {
            var result = _restaurantService.DeleteRestaurant(id);
            if (result is null)
                return NotFound("Restaurant Not Found");

            return Ok(result);
        }
    }
}
