using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        public ActionResult Index()
        {
            var bloglar = c.Blogs.ToList();
            return View(bloglar);
        }
        public ActionResult BlogDetay(int id)
        {
            BlogYorum by = new BlogYorum();

            by.Deger1 = c.Blogs.Where(b => b.Id == id).FirstOrDefault();
            by.Deger2 = c.Yorums.Where(y => y.BlogId == id).ToList();

            return View(by);
        }
    }
}