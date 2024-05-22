using HealthEase.Models;

namespace HealthEase.ViewModels
{
    public class DoctorAppointmentsModel
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<Appointment> Appointments;
    }
}
