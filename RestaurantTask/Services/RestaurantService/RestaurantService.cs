using Microsoft.EntityFrameworkCore;
using RestaurantTask.Data;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private readonly DataContext _context;
        public RestaurantService(DataContext context)
        {
            _context = context;
        }

        public Restaurant AddRestaurant(RestaurantDto restaurant)
        {
            var newRestaurant = new Restaurant()
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                PhoneNumber = restaurant.PhoneNumber,
                OpenTime = restaurant.OpenTime,
                CloseTime = restaurant.CloseTime,
            };
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();
            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var ToDeleteRestaurant = _context.Restaurants.Find(id);
            _context.Restaurants.Remove(ToDeleteRestaurant);
            _context.SaveChanges();
            return ToDeleteRestaurant;
        }

        public List<Restaurant> GetAllRestaurants()
        {
             return _context.Restaurants
            .Include(rt => rt.RestaurantTables)
            .ToList();
        }
    
        public Restaurant GetSingleRestaurant(int id)
        {
        var restaurant = _context.Restaurants
            .Include(rt => rt.RestaurantTables)
            .FirstOrDefault(r => r.Id == id);
            return restaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public List<Restaurant> GetRestaurantsByName(string name)
        {
            var words = name.Split(' ');
            var restaurants = _context.Restaurants
              .AsEnumerable()
              .Where(r => words.Any(word => r.Name.Contains(word, StringComparison.OrdinalIgnoreCase)))
              .ToList();

            return restaurants;
        }
    }   
}
