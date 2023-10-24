namespace RestaurantTask.Models
{
    public class TableType
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public RestaurantTable? RestaurantTable { get; set; }
    }
}
