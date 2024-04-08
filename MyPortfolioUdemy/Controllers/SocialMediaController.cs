using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class SocialMediaController : Controller
	{
		MyPortfolioContext c = new MyPortfolioContext();
		public IActionResult SocialMediaList()
		{
			var values = c.SocialMedias.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateSocialMedia()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateSocialMedia(SocialMedia p)
		{
			c.SocialMedias.Add(p);
			c.SaveChanges();
			return RedirectToAction("SocialMediaList");
		}

		public IActionResult DeleteSocialMedia(int id)
		{
			var values = c.SocialMedias.Find(id);
			c.SocialMedias.Remove(values);
			c.SaveChanges();
			return RedirectToAction("SocialMediaList");
		}

		[HttpGet]
		public IActionResult UpdateSocialMedia(int id)
		{
			var values = c.SocialMedias.Find(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateSocialMedia(SocialMedia p)
		{
			c.SocialMedias.Update(p);
			c.SaveChanges();
			return RedirectToAction("SocialMediaList");
		}

	}
}
