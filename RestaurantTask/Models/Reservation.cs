namespace RestaurantTask.Models
{
    public class Reservation
    {
        public int Id  { get; set; }
        public DateTime ReservationTime { get; set; }
        public RestaurantTable? RestaurantTable { get; set;}
        public AppUser? User { get; set; } 
        public bool isCancelled{ get; set; } = false; 
    }
}
