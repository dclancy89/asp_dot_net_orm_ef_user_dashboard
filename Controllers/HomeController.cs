using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserDashboard.Models;

namespace UserDashboard.Controllers
{
    public class HomeController : Controller
    {
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
                return RedirectToAction("Signin");
            }
            return RedirectToAction("Index");
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

            if(ModelState.IsValid)
            {
                
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
