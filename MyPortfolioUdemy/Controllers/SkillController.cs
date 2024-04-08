using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class SkillController : Controller
	{
		MyPortfolioContext c = new MyPortfolioContext();
		public IActionResult SkillList()
		{
			var values = c.Skills.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateSkill()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateSkill(Skill p)
		{
			c.Skills.Add(p);
			c.SaveChanges();
			return RedirectToAction("SkillList");
		}

		public IActionResult DeleteSkill(int id)
		{
			var values = c.Skills.Find(id);
			c.Skills.Remove(values);
			c.SaveChanges();
			return RedirectToAction("SkillList");
		}
		[HttpGet]
		public IActionResult UpdateSkill(int id)
		{
			var values = c.Skills.Find(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateSkill(Skill p)
		{
			c.Skills.Update(p);
			c.SaveChanges();
			return RedirectToAction("SkillList");
		}
	}
}
