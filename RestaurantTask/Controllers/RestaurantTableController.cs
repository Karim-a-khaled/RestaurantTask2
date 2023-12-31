﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;
using RestaurantTask.Services.RestaurantTableService;

namespace RestaurantTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class RestaurantTableController : ControllerBase
    {
        private readonly IRestaurantTableService _restaurantTableService;
        public RestaurantTableController(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<RestaurantTable>> GetAllRestaurantTables()
        {
            var restaurantTable = _restaurantTableService.GetAllRestaurantTables();
            return Ok(restaurantTable);
        }

        [HttpGet("GetById")]
        public ActionResult<RestaurantTable> GetSingleRestaurantTable(int id)
        {
            var result = _restaurantTableService.GetSingleRestaurantTable(id);
            if (result is null)
                return NotFound("Table Not Found");

            return Ok(result);
        }

       [HttpPost]
        public ActionResult<RestaurantTableDto> Post(RestaurantTableDto restaurantTable)
        {
            var result = _restaurantTableService.AddRestaurantTable(restaurantTable);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<RestaurantTableDto> Update(int id, RestaurantTableDto restaurantTableInput)
        {
            var restaurantTable = _restaurantTableService.GetSingleRestaurantTable(id);

            if (restaurantTable is null)
            {
                return NotFound("Table Not Found");
            }

            restaurantTable.NumberOfSeats = restaurantTableInput.NumberOfSeats;


            var result = _restaurantTableService.UpdateRestaurantTable(id, restaurantTable);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<RestaurantTable> DeleteRestaurantTable(int id)
        {
            var result = _restaurantTableService.DeleteRestaurantTable(id);
            if (result is null)
                return NotFound("Table Not Found");

            return Ok(result);
        }
    }
}
