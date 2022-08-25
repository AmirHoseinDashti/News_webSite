using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayrer;

namespace My_NewsSite.Controllers
{
    public class SearchController : Controller
    {
        My_SiteContext db = new My_SiteContext();
        private IPageRepository PageRepository;
        public SearchController()
        {
            PageRepository = new PageRepository(db);
        }

        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(PageRepository.SearchPage(q));
        }
    }
}