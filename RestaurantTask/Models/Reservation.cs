namespace RestaurantTask.Models
{
    public class Reservation
    {
        public int Id  { get; set; }
        public DateTime ReservationTime { get; set; }
        public RestaurantTable RestaurantTable { get; set;} = new RestaurantTable();
        public AppUser User { get; set; } = new AppUser();
        public bool isCancelled{ get; set; } = false;
    }
}
