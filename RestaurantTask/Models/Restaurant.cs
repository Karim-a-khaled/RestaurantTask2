namespace RestaurantTask.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; }= string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public List<RestaurantTable> RestaurantTables{ get; set; } = new List<RestaurantTable>();
    }
}
