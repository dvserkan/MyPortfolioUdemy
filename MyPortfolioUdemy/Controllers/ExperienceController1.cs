﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class ExperienceController1 : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult ExperienceList()
		{
			var values = context.Experiences.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateExperience()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateExperience(Experience p)
		{
			context.Experiences.Add(p);
			context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}
		public IActionResult DeleteExperience(int id)
		{
			var values = context.Experiences.Find(id);
			context.Experiences.Remove(values);
			context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}
		[HttpGet]
		public IActionResult UpdateExperience(int id)
		{
			var values = context.Experiences.Find(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult UpdateExperience(Experience p)
		{
			context.Experiences.Update(p);
			context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}

	}
}
