using HealthEase.Models;
using HealthEase.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealthEase.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IRepository<Department> Department { get; }
        public HomeController(IRepository<Department>_Department)
        {
            Department = _Department;
        }
        public IActionResult Index()
        {
            var data= Department.ViewFormClient();
            return View(data);
        }
        
    }
}
