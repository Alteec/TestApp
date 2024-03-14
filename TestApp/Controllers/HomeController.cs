using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Models;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		PostRepository repositoryPosts = new PostRepository();
		UserRepository repositoryUsers = new UserRepository();



		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Posts"]= repositoryPosts.GetPosts();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Login(string ReturnUrl)
        {
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
        }

		[HttpPost]
		public IActionResult Login(string email, string password, string ReturnUrl)
		{
            var user=repositoryUsers.GetUserByEmail(email);
			if (user is not null && user.Password==password)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, email)
				};
				var claimsIdentity = new ClaimsIdentity(claims, "Login");

				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                if(ReturnUrl is not null)
                {
                    return Redirect(ReturnUrl);

                }
                return Redirect("AboutUs");
            }

			return View();
		}

		public IActionResult SignUp()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SignUp(string email, string password)
        {
            var user = repositoryUsers.GetUserByEmail(email);
            if(user is null)
            {
                repositoryUsers.InsertUser(email, password);
                return Redirect("Login");

            }
            return View();
        }
        public IActionResult AboutUs()
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
