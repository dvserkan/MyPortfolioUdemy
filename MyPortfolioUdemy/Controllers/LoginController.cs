using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;
using System.Security.Claims;

namespace MyPortfolioUdemy.Controllers
{
	
	public class LoginController : Controller
	{
		MyPortfolioContext c = new MyPortfolioContext();


		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Index(Login p)
		{
			var values = c.Logins.FirstOrDefault(x => x.username == p.username && x.password == p.password);

			if (values != null)
			{
				var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.Name,p.username)
				};
				var useridentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "ToDoList");
			}
			return View();
		}
		public async Task<IActionResult> CikisYap()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login");
		}
	}
}
