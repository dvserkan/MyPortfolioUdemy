using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioContext c = new MyPortfolioContext();
        public IActionResult AboutList()
        {
            var values = c.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAbout(About p)
        {
            c.Abouts.Add(p);
            c.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public IActionResult DeleteAbout(int id)
        {
            var values = c.Abouts.Find(id);
            c.Abouts.Remove(values);
            c.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id) 
        {
            var values = c.Abouts.Find(id);
            return View(values);    

        }
		[HttpPost]
		public IActionResult UpdateAbout(About p)
		{
			c.Abouts.Update(p);
            c.SaveChanges();
            return RedirectToAction("AboutList");

		}


	}
}
