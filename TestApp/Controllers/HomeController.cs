using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Models;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Data.DataContext;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _db;





        public HomeController(DataContext db,ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List","Post");
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult AboutUs()
		{
			return View();
		}



	}
}
