using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AboutController : Controller
    {
        LearnerContext context = new LearnerContext();  
        public ActionResult Index()
        {
            var value = context.Abouts.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            var value = context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutID);
            value.AboutID = about.AboutID;
            value.Title = about.Title;
            value.Description = about.Description;  
            value.ImageUrl=about.ImageUrl;  
            value.Item1= about.Item1;   
            value.Item2= about.Item2;
            value.Item3= about.Item3;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}