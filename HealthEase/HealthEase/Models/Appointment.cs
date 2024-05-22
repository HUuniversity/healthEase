namespace HealthEase.Models
{
    public class Appointment:BaseEntity
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
