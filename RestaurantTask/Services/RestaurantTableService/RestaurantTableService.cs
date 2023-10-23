using Microsoft.EntityFrameworkCore;
using RestaurantTask.Data;
using RestaurantTask.Models;
using RestaurantTask.Models.DTOS;

namespace RestaurantTask.Services.RestaurantTableService
{   
        public class RestaurantTableService : IRestaurantTableService
        {
            private readonly DataContext _context;
            public RestaurantTableService(DataContext context)
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
                var restuarantTable = _context.RestaurantTables
                    .Include(rt => rt.Restaurant)
                    .Include(rt => rt.Reservations)
                    .Include(rt => rt.TableType)
                    .FirstOrDefault(u => u.Id == id);

                return restuarantTable;
            }

            public RestaurantTable UpdateRestaurantTable(int id, RestaurantTable restaurantTable)
            {
                _context.RestaurantTables.Update(restaurantTable);
                _context.SaveChanges();
                return restaurantTable;
            }
        }
    }
