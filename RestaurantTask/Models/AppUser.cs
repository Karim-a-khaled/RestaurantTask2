using Microsoft.AspNetCore.Identity;

namespace RestaurantTask.Models
{
    public class AppUser : IdentityUser
    {
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
