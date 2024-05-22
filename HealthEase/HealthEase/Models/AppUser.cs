using Microsoft.AspNetCore.Identity;

namespace HealthEase.Models
{
    public class AppUser:IdentityUser
    {
        public int TableId { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}
