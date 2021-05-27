using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using TrainingPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace TrainingPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult TestAut()
        {
            string str = "";
            foreach(var claim in User.Claims.ToList())
            {
                str += claim.Value +"\n";
            }
            return Content(str);
        }

        [Authorize(Roles = "Admin, Editor")]
        public IActionResult TestRole()
        {
            string str = "";
            foreach(var claim in User.Claims.ToList())
            {
                str += claim.Value +"\n";
            }
            return Content(str);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
