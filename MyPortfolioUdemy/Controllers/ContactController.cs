using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class ContactController : Controller
	{
		MyPortfolioContext c = new MyPortfolioContext();
		public IActionResult ContactList()
		{
			var values = c.Contacts.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateContact(Contact p)
		{
			c.Contacts.Add(p);
			c.SaveChanges();
			return RedirectToAction("ContactList");
		}

		public IActionResult DeleteContact(int id)
		{
			var values = c.Contacts.Find(id);
			c.Contacts.Remove(values);
			c.SaveChanges();
			return RedirectToAction("ContactList");
		}
		[HttpGet]
		public IActionResult UpdateContact(int id)
		{
			var values = c.Contacts.Find(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult UpdateContact(Contact p)
		{
			c.Contacts.Update(p);
			c.SaveChanges();
			return RedirectToAction("ContactList");
		}

	}
}
