namespace RestaurantTask.Models.DTOS
{
    public class ReservationInput
    {
        public DateTime ReservationTime { get; set; }
        public bool isCancelled { get; set; } = false;
    }
}
