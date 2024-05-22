using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthEase.Models
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Adminn> Adminn { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<UserType> UserType { get; set; }
    }
}
