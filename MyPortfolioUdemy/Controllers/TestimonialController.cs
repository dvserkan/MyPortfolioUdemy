using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class TestimonialController : Controller
	{
		MyPortfolioContext c = new MyPortfolioContext();
		public IActionResult TestimonialList()
		{
			var values = c.Testimonials.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateTestimonial()
		{
			return View();
		}

		[HttpPost] 
		public IActionResult CreateTestimonial(Testimonial p)
		{
			c.Testimonials.Add(p);
			c.SaveChanges();
			return RedirectToAction("TestimonialList");
		}
		
		public IActionResult DeleteTestimonial(int id)
		{
			var values = c.Testimonials.Find(id);
			c.Testimonials.Remove(values);
			c.SaveChanges();
			return RedirectToAction("TestimonialList");
		}
		[HttpGet]

		public IActionResult UpdateTestimonial(int id)
		{
			var values = c.Testimonials.Find(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateTestimonial(Testimonial p)
		{
			c.Testimonials.Update(p);
			c.SaveChanges();
			return RedirectToAction("TestimonialList");
		}


	}
}
