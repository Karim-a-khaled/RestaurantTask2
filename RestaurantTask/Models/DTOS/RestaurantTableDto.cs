namespace RestaurantTask.Models.DTOS
{
    public class RestaurantTableDto
    {
        public decimal Price{ get; set; }
        public bool isIndoor { get; set; } = false;
        public bool isOutdoor { get; set; } = false;
        public bool isLounge { get; set; } = false;
        public int NumberOfSeats { get; set; }
    }
}
