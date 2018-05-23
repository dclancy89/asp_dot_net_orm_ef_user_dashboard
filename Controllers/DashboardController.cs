using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserDashboard.Models;

namespace UserDashboard.Controllers
{
    public class DashboardController : Controller
    {

        private User ActiveUser = null;
    
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}