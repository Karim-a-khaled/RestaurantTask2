using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;
using RestaurantTask.Services.RestaurantTableService;

namespace RestaurantTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTableController : ControllerBase
    {
        private readonly IRestaurantTableService _restaurantTableService;
        public RestaurantTableController(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Table>> GetAllRestaurantTables()
        {
            var tables = _restaurantTableService.GetAllRestaurantTables();
            return Ok(tables);
        }

        [HttpGet("GetById")]
        public ActionResult<Table> GetSingleRestaurantTable(int id)
        {
            var result = _restaurantTableService.GetSingleRestaurantTable(id);
            if (result is null)
                return NotFound("Table Not Found");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Table> Post(RestaurantTableInput restaurantTable)
        {
            var result = _restaurantTableService.AddRestaurantTable(restaurantTable);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<RestaurantTable> UpdateRestaurantTable(RestaurantTable restaurantTable)
        {
            var result = _restaurantTableService.UpdateRestaurantTable(restaurantTable.Id, restaurantTable);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<Table> DeleteRestaurantTable(int id)
        {
            var result = _restaurantTableService.DeleteRestaurantTable(id);
            if (result == null)
                return NotFound("Table Not Found");

            return Ok(result);
        }
    }
}
