namespace RestaurantTask.DTO
{
    public class UserManagerResponse
    {
        public string Message{ get; set; }
        public bool isSuccess { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public DateTime? ExpireDate{ get; set; }
    }
}
