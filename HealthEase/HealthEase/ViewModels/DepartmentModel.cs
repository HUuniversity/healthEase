using HealthEase.Models;

namespace HealthEase.ViewModels
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
