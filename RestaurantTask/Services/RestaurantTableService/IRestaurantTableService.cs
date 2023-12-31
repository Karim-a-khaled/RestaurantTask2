﻿using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Services.RestaurantTableService
{
    public interface IRestaurantTableService
    {
        List<RestaurantTable> GetAllRestaurantTables();
        RestaurantTable GetSingleRestaurantTable(int id);
        RestaurantTable AddRestaurantTable(RestaurantTableDto table);
        RestaurantTable UpdateRestaurantTable(int id, RestaurantTable request);
        RestaurantTable DeleteRestaurantTable(int id);
    }
}
