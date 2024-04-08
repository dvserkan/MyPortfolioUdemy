using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		MyPortfolioContext c = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.todolistcount = c.ToDoLists.Where(x=> x.Status == false).Count();
			var values = c.ToDoLists.Where(x => x.Status == false).ToList();
			return View(values);
		}
	}
}
