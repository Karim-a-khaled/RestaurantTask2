using System.ComponentModel.DataAnnotations;

namespace RestaurantTask.DTO
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email{ get; set; }
        [Required]
        [StringLength(50)]
        public string Password{ get; set; }
    }
}
