using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var bloglar = c.Blogs.ToList();
            return View(bloglar);
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
        public PartialViewResult LastBlogs()
        {
           var blogs = c.Blogs.OrderByDescending(x => x.Id).Take(10).ToList();
            return PartialView(blogs);
        }
        public PartialViewResult Begenilen()
        {
            
            return PartialView();
        }
    }
}