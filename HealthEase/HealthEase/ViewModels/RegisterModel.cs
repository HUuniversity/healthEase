using System.ComponentModel.DataAnnotations;

namespace HealthEase.ViewModels
{
    public class RegisterModel
    {
        public string PatientNId { get; set; }
        public string PatientName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
