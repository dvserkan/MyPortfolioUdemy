using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
	public class _FeatureComponentPartial : ViewComponent
	{
		MyPortfolioContext portfolioContext = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			var values = portfolioContext.Features.ToList();

			ViewBag.face = portfolioContext.SocialMedias.Where(x=> x.Title == "Facebook").Select(y=> y.Url).FirstOrDefault();
			ViewBag.linkedin = portfolioContext.SocialMedias.Where(x=> x.Title == "Linkedin").Select(y=> y.Url).FirstOrDefault();
			ViewBag.inst = portfolioContext.SocialMedias.Where(x=> x.Title == "Instagram").Select(y=> y.Url).FirstOrDefault();
			ViewBag.github = portfolioContext.SocialMedias.Where(x=> x.Title == "Github").Select(y=> y.Url).FirstOrDefault();

			return View(values);
		}
	}
}
