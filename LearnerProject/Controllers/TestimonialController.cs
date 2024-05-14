using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class TestimonialController : Controller
    {
        LearnerContext context= new LearnerContext();
        public ActionResult Index()
        {
            var value = context.Testimonials.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
     
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonials.Find(testimonial.TestimonialID);
            value.TestimonialID= testimonial.TestimonialID; 
            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.ImageUrl=testimonial.ImageUrl;
            value.Comment= testimonial.Comment;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}