using HealthEase.Models;
using HealthEase.Models.Repositories;
using HealthEase.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthEase.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        public IRepository<Department> Department { get; }
        public IRepository<Doctor> Doctor { get; }
        public IRepository<Appointment> Appointment { get; }

        public MainController(IRepository<Department>_Department,IRepository<Doctor>_Doctor,IRepository<Appointment> _Appointment)
        {
            Department = _Department;
            Doctor = _Doctor;
            Appointment = _Appointment;
        }
        // GET: MainController
        public IActionResult Index()
        {
            var data = new HomeModel();
            data.Department=Department.ViewFormClient().ToList();
            return View(data);
        }
        public IActionResult GetDepartment(int id)
        {
            DepartmentModel obj = new DepartmentModel();
            obj.DepartmentId = id;
            obj.Department = Department.Find(id);
            obj.Doctors=Doctor.ViewFormClient().Where(x=>x.DepartmentId==id).ToList();
            return View(obj);
        }
        public IActionResult GetDoctorAppointments(int id)
        {
            DoctorAppointmentsModel obj = new DoctorAppointmentsModel();
           obj.DoctorId = id;
            obj.Doctor=Doctor.Find(id);
            obj.Appointments=Appointment.ViewFormClient().Where(x => x.AppointmentId == id).ToList();
            return View(obj);
        }

        // GET: MainController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
