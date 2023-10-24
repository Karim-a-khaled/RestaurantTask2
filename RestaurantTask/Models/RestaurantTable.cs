namespace RestaurantTask.Models
{
    public class RestaurantTable
    {
        public int Id { get; set; }
        public int NumberOfSeats{ get; set; }
        public bool isIndoor { get; set; } = false;
        public bool isOutdoor { get; set; } = false;
        public bool isLounge { get; set; } = false; 
        public decimal Price { get; set; } 

        public Restaurant? Restaurant { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        //public TableType? TableType { get; set; }
    }
}
