using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Bloglar()
        {
            var bloglar = c.Blogs.ToList();
            return View(bloglar);
        }
        public ActionResult Yorumlar()
        {
            var yorumlar = c.Yorums.ToList();
            return View(yorumlar);
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BlogEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogEkle(Blog blog)
        {
            blog.Tarih = DateTime.Now;
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Bloglar");
        }
        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.FirstOrDefault(b => b.Id == id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Bloglar");
        }
        [HttpGet]
        public ActionResult BlogGuncelle(int id)
        {
            var blog = c.Blogs.FirstOrDefault(b => b.Id == id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult BlogGuncelle(Blog blg)
        {
            var blog = c.Blogs.FirstOrDefault(b => b.Id == blg.Id);
            blog.Baslik = blg.Baslik;
            blog.Aciklama = blg.Aciklama;
            blog.BlogImage = blg.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Bloglar");
        }
        [HttpGet]
        public ActionResult YorumGuncelle(int id)
        {
            var yorum = c.Yorums.FirstOrDefault(y => y.Id == id);
            return View(yorum);
        }
        [HttpPost]
        public ActionResult YorumGuncelle(Yorum yrm)
        {
            var yorum = c.Yorums.FirstOrDefault(y => y.Id == yrm.Id);
            yorum.YapilanYorum = yrm.YapilanYorum;
            c.SaveChanges();
            return RedirectToAction("Yorumlar");
        }
        public ActionResult YorumSil(int id)
        {
            var yorum = c.Yorums.FirstOrDefault(y => y.Id == id);
            c.Yorums.Remove(yorum);
            c.SaveChanges();
            return RedirectToAction("Yorumlar");
        }
    }
}