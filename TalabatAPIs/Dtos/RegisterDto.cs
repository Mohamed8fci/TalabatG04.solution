using System.ComponentModel.DataAnnotations;

namespace TalabatAPIs.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 1 number, 1 special character, and at least 6 characters.")]
        public string Password { get; set; }
    }
}
