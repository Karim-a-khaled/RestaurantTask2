namespace RestaurantTask.Models.DTOS
{
    public class ReservationDto
    {
        public DateTime ReservationTime { get; set; }
        public bool isCancelled { get; set; } = false;
    }
}
