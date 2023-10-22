namespace RestaurantTask.Models
{
    public class RestaurantTable
    {
        public int Id { get; set; }
        public int NumberOfSeats{ get; set; }
        public Restaurant Restaurant { get; set; } = new Restaurant();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public TableType TableType { get; set; } = new TableType();
    }
}
