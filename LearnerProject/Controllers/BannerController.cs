using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class BannerController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var value = context.Banners.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult AddBanner(Banner banner)
        {
            var value = context.Banners.Add(banner);
            context.SaveChanges();
            return View(value);
        }
        public ActionResult DeleteBanner(int id)
        {
            var value = context.Banners.Find(id);
            context.Banners.Remove(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = context.Banners.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            var value = context.Banners.Find(banner.BannerID);
            value.BannerID = banner.BannerID;
            value.Title = banner.Title; 
            context.SaveChanges();
            return RedirectToAction("Index");

        }

      
    }
}