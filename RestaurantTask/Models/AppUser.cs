using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace RestaurantTask.Models
{
    public class AppUser : IdentityUser
    {
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
