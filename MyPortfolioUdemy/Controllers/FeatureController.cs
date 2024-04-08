using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class FeatureController : Controller
	{
		MyPortfolioContext c = new MyPortfolioContext();
		public IActionResult FeatureList()
		{
			var values = c.Features.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateFeature()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateFeature(Feature p)
		{
			c.Features.Add(p);
			c.SaveChanges();
			return RedirectToAction("FeatureList");
		}
		public IActionResult DeleteFeature(int id)
		{
			var values = c.Features.Find(id);
			c.Features.Remove(values);
			c.SaveChanges();
			return RedirectToAction("FeatureList");

		}
		[HttpGet]
		public IActionResult UpdateFeature(int id)
		{
			var values = c.Features.Find(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult UpdateFeature(Feature p)
		{
			c.Features.Update(p);
			c.SaveChanges();
			return RedirectToAction("FeatureList");
		}

	}
}
