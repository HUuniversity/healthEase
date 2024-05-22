namespace HealthEase.Models
{
    public class Doctor : BaseEntity
    {
        public int DoctorId { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPassword { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorImage { get; set; }
        public string DoctorMajor { get; set; }

        public string DoctorGender { get; set; }
        public string DoctorAcheivment { get; set; }
        List<DayOfWeek> DoctorDays { get; set; }
        public DateTime DoctorStartTime { get; set; }
        public DateTime DoctorEndTime { get; set; }
        public DateTime DoctorAppointmentDuration { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
