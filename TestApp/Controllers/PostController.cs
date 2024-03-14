using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
	public class PostController : Controller
	{
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}
	}
}
