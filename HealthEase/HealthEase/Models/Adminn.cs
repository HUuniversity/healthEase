namespace HealthEase.Models
{
    public class Adminn:BaseEntity
    {
        public int AdminnId { get; set; }
        public string AdminnUserName { get; set; }
        public string AdminnPassword { get; set; }
        public string AdminnEmail { get; set; }
        public string AdminnFirstName { get; set; }
        public string AdminnLastName { get; set; }
    }
}
