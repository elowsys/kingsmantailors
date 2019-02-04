using System.ComponentModel.DataAnnotations;

namespace KingsmanTailors.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must have a minimum of 8 and a maximum of 32 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Display name is required")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        public string RoleCode { get; set; }

        public string Gender { get; set; }
    }
}
