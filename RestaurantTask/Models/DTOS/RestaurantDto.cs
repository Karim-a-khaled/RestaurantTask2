namespace RestaurantTask.Models.DTOS
{
    public class RestaurantDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
