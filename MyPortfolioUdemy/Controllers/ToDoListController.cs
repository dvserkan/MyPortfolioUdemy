using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class ToDoListController : Controller
	{
		MyPortfolioContext c = new MyPortfolioContext();
		public IActionResult Index()
		{
			var values = c.ToDoLists.ToList();

			ViewBag.v1 = c.Skills.Count();
			ViewBag.v2 = c.Messages.Count();
			ViewBag.v3 = c.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.v4 = c.Messages.Where(x => x.IsRead == true).Count();


			return View(values);
		}
		[HttpGet]
		public IActionResult CreateToDoList()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateToDoList(ToDoList p)
		{
			c.ToDoLists.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteToDoList(int id)
		{
			var values = c.ToDoLists.Find(id);
			c.ToDoLists.Remove(values);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateToDoList(int id)
		{
			var values = c.ToDoLists.Find(id);
			return View(values);
		}

		[HttpPost]
		public ActionResult UpdateToDoList(ToDoList p)
		{
			c.ToDoLists.Update(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult ChangeToDoListStatusToTrue(int id)
		{
			var value = c.ToDoLists.Find(id);
			value.Status = true;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult ChangeToDoListStatusToFalse(int id)
		{
			var value = c.ToDoLists.Find(id);
			value.Status = false;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
