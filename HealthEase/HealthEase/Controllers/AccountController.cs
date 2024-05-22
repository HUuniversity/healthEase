using HealthEase.Models;
using HealthEase.Models.Repositories;
using HealthEase.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthEase.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public IRepository<Patient> Patient { get; }

        public AccountController(UserManager<IdentityUser> _UserManager, SignInManager<IdentityUser> _SignInManager,IRepository<Patient> Patient)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
            this.Patient = Patient;
        }
        public ActionResult Register()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "User-Name or Password is Incorrect");
                    return View();
                }
                var user = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.PatientNId//collection.Email,

                    /*PasswordHash = collection.Password;*/
                    /*EmailConfirmed = true,
                    PhoneNumberConfirmed=true,
                    TwoFactorEnabled=false,
                    LockoutEnabled=false,
                    AccessFailedCount=0*/

                };
                var Res = UserManager.CreateAsync(user, collection.Password).Result;
                if (Res.Succeeded)
                {
                    /*Patient obj = new Patient{
                        PatientEmail = collection.Email,
                        PatientFirstName = collection.PatientName,
                        PatientLastName = collection.PatientName,
                        PatientNId = collection.PatientNId,
                        CreateDate = DateTime.UtcNow,
                        CreateUser = "1"
                    };*/
                    SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }

                ModelState.AddModelError("", "User-Name or Password is Incorrect");
                return View();


                /*  return RedirectToAction(nameof(Register));*/
            }
            catch
            {
                return View();
            }
        }
        // GET: AccountController
        public ActionResult Login()
        {
            return View();
        }


        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "User-Name or Password is Incorrect");
                    return View();
                }
                /* ModelState.ClearValidationState(nameof(collection));
                 if (!TryValidateModel(collection, nameof(collection)))
                 {
                     return View();
                 }*/
                //var Res = SignInManager.PasswordSignInAsync(collection.Email, collection.Password,
                //    isPersistent: collection.RememberMe, false).Result;
                var Res = SignInManager.PasswordSignInAsync(collection.PatientNId, collection.Password,
                    isPersistent: collection.RememberMe, false).Result;
                if (Res.Succeeded)
                {
                    return RedirectToAction("Index", "Main");
                }
                /*var user = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email,
                    *//*PasswordHash = collection.Password;*//*
                };
                var Res = UserManager.CreateAsync(user, collection.Password).Result;
                if (Res.Succeeded)
                {
                    SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Category");
                }

*/
                ModelState.AddModelError("", "User-Name or Password is Incorrect");
                return View();

                /*  return RedirectToAction(nameof(Register));*/
            }
            catch
            {
                return View();
            }
        }

    }
}
