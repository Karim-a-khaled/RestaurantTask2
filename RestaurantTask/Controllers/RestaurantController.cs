using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTask.Models.DTOS;
using RestaurantTask.Models;
using RestaurantTask.Services.RestaurantService;

namespace RestaurantTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<RestaurantInput>> GetAllRestaurants()
        {
            var restaurant = _restaurantService.GetAllRestaurants();
            return Ok(restaurant);
        }

        [HttpGet("GetById")]
        public ActionResult<RestaurantInput> GetSingle(int id)
        {
            var result = _restaurantService.GetSingleRestaurant(id);
            if (result is null)
                return NotFound("Restaurant Not Found");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<RestaurantInput> Post(RestaurantInput restaurant)
        {
            var result = _restaurantService.AddRestaurant(restaurant);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<RestaurantInput> Update(Restaurant restaurant)
        {
            var result = _restaurantService.UpdateRestaurant(restaurant.Id, restaurant);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<Restaurant> Delete(int id)
        {
            var result = _restaurantService.DeleteRestaurant(id);
            if (result == null)
                return NotFound("Restaurant Not Found");

            return Ok(result);
        }
    }
}
