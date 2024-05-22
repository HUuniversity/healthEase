namespace HealthEase.Models
{
    public class Patient : BaseEntity
    {
        public int PatientId { get; set; }
        public string PatientNId { get; set; }
        public string PatientNationality { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPassword { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientImage { get; set; }
        public string PatientAge { get; set; }
        public string PatientGender { get; set; }
    }
}
