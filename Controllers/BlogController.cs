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
            BlogYorum by = new BlogYorum();
            by.Deger3 = c.Blogs.ToList();
            by.Deger4 = c.Blogs.OrderByDescending(x => x.Id).Take(5).ToList();
            by.Deger2 = c.Yorums.OrderByDescending(x => x.Id).Take(5).ToList();
            return View(by);
        }
        public ActionResult BlogDetay(int id)
        {
            BlogYorum by = new BlogYorum();

            by.Deger1 = c.Blogs.Where(b => b.Id == id).FirstOrDefault();
            by.Deger2 = c.Yorums.Where(y => y.BlogId == id).ToList();

            return View(by);
        }
        public PartialViewResult YorumYap1(int id)
        {
            ViewBag.Blogid = id;
            return PartialView();
        }
        [HttpPost]
        public ActionResult YorumYap(Yorum yorum)
        {
            c.Yorums.Add(yorum);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
