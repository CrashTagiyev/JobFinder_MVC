using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobFinder_Presentation.Areas.AllUsers.Controllers
{
	[Area("AllUsers")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
