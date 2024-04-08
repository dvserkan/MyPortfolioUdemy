using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class PortfolyoController : Controller
	{
		MyPortfolioContext c = new MyPortfolioContext();
		public IActionResult PortfolyoList()
		{
			var values = c.Portfolios.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreatePortfolyo()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreatePortfolyo(Portfolio p)
		{

			c.Portfolios.Add(p);
			c.SaveChanges();
			return RedirectToAction("PortfolyoList");
		}

		public IActionResult DeletePortfolyo(int id)
		{

			var values = c.Portfolios.Find(id);
			c.Portfolios.Remove(values);
			c.SaveChanges();
			return RedirectToAction("PortfolyoList");
		}

		[HttpGet]
		public IActionResult UpdatePortfolyo(int id)
		{
			var values = c.Portfolios.Find(id);
			return View(values);	
		}
		[HttpPost]
		public IActionResult UpdatePortfolyo(Portfolio p)
		{
			c.Portfolios.Update(p);
			c.SaveChanges();
			return RedirectToAction("PortfolyoList");
		}


	}
}
