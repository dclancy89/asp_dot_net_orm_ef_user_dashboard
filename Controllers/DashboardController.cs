using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserDashboard.Models;
using System.Linq;

namespace UserDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private UDContext _context;
        private User ActiveUser 
        {
            get{ return _context.Users.Where(u => u.Id == HttpContext.Session.GetInt32("id")).FirstOrDefault();}
        }

        public DashboardController(UDContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.User = ActiveUser;
            ViewBag.AllUsers = _context.Users.ToList();
            return View();
        }
    }
}