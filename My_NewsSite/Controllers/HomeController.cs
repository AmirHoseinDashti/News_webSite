using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayrer;

namespace My_NewsSite.Controllers
{
    public class HomeController : Controller
    {
        My_SiteContext db = new My_SiteContext();

        private PageRepository PageRepository;

        public HomeController()
        {
            PageRepository = new PageRepository(db);
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Slider()
        {
            return PartialView(PageRepository.PagesInSlider());
        }
    }
}