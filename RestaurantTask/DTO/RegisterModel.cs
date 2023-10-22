using System.ComponentModel.DataAnnotations;

namespace RestaurantTask.DTO
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50,MinimumLength =5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}
