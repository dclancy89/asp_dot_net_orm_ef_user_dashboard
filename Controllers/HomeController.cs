using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserDashboard.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace UserDashboard.Controllers
{
    public class HomeController : Controller
    {
        private UDContext _context;

        public HomeController(UDContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("signin")]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [Route("user/signin")]
        public IActionResult SigninUser(SigninViewModel user)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                User myUser = _context.Users.SingleOrDefault(User => User.Email == user.Email);
                if(myUser != null)
                {
                    if(hasher.VerifyHashedPassword(myUser, myUser.Password, user.Password) == PasswordVerificationResult.Success)
                    {
                        HttpContext.Session.SetInt32("id", myUser.Id);
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else {
                        TempData["Login Error"] = "Incorrect Password";
                    }
                }
                else 
                {
                    TempData["Login Error"] = "This user does not exist.";
                }
            }
            else
            {
                foreach(var modelState in ModelState.Values)
                {
                    foreach(var error in modelState.Errors)
                    {
                        TempData[error.ErrorMessage] = error.ErrorMessage;
                    }
                }
            }
            return RedirectToAction("Signin");
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            ViewBag.Errors = TempData["Errors"];
            return View();
        }

        [HttpPost]
        [Route("user/new")]
        public IActionResult RegisterUser(RegisterViewModel user)
        {
            // Check for Form Validation
            if(ModelState.IsValid)
            {
                if(_context.Users.SingleOrDefault(User => User.Email == user.Email) == null)
                {
                    PasswordHasher<User> hasher = new PasswordHasher<User>();
                    User newUser = new User
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserLevel = 1,
                        Description = "None",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    newUser.Password = hasher.HashPassword(newUser, user.Password);

                    User myUser = _context.Users.Add(newUser).Entity;
                    if(myUser.Id == 1)
                    {
                        myUser.UserLevel = 10;
                    }
                    _context.SaveChanges();

                    HttpContext.Session.SetInt32("id", myUser.Id);

                }
                else {
                    TempData["Duplicate User Error"] = "This user already exists";
                    return RedirectToAction("Register");
                }
                
            }
            else
            {
                foreach(var modelState in ModelState.Values)
                {
                    foreach(var error in modelState.Errors)
                    {
                        TempData[error.ErrorMessage] = error.ErrorMessage;
                    }
                }
                return RedirectToAction("Register");
            }
            return RedirectToAction("Index");
        }
    }
}
