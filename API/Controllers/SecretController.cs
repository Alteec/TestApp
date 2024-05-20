using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class SecretController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> GetSecrets()
		{
			return null;
		}

	}
}
