using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantTask.Data;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;
using static RestaurantTask.Services.RestaurantTableService.RestaurantTableService;

namespace RestaurantTask.Services.RestaurantTableService
{
    public class RestaurantTableService
    {
        public class RestaurantTableServices : IRestaurantTableService
        {
            private readonly DataContext _context;
            public RestaurantTableServices(DataContext context)
            {
                _context = context;
            }

            public RestaurantTable AddRestaurantTable(RestaurantTableInput restaurantTable)
            {
                var newRestaurantTable = new RestaurantTable()
                {
                    NumberOfSeats = restaurantTable.NumberOfSeats,
                };
                _context.RestaurantTables.Add(newRestaurantTable);
                _context.SaveChanges();
                return newRestaurantTable;
            }

            public RestaurantTable DeleteRestaurantTable(int id)
            {
                var toDeleteTable = _context.RestaurantTables.Find(id);
                _context.RestaurantTables.Remove(toDeleteTable);
                _context.SaveChanges();
                return toDeleteTable;
            }

            public List<RestaurantTable> GetAllRestaurantTables()
            {
                return _context.RestaurantTables
                    .Include(rt => rt.Restaurant)
                    .Include(rt => rt.Reservations)
                    .Include(rt => rt.TableType)
                    .ToList();
            }

            public RestaurantTable GetSingleRestaurantTable(int id)
            {
                var table = _context.RestaurantTables
                    .Include(rt => rt.Restaurant)
                    .Include(rt => rt.Reservations)
                    .Include(rt => rt.TableType)
                    .FirstOrDefault(u => u.Id == id);

                return table;
            }

            public RestaurantTable UpdateRestaurantTable(int id, RestaurantTable restaurantTable)
            {
                _context.RestaurantTables.Update(restaurantTable);
                _context.SaveChanges();
                return restaurantTable;
            }
        }
    }
}