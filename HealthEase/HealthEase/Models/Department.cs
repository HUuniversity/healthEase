namespace HealthEase.Models
{
    public class Department:BaseEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public string DepartmentImage { get; set; }

    }
}
