using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Services.RestaurantService
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant GetSingleRestaurant(int id);
        List<Restaurant> GetRestaurantsByName(string name);
        Restaurant AddRestaurant(RestaurantDto restaurant);
        Restaurant UpdateRestaurant(int id, Restaurant request);
        Restaurant DeleteRestaurant(int id);
    }
}
