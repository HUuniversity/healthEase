using System.ComponentModel.DataAnnotations;

namespace HealthEase.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string PatientNId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
