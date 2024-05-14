using LearnerProject.Models;
using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultCoursePartial()
        {
            var values = context.Courses.Include(x=>x.Reviews).OrderByDescending(x=>x.CourseID).Take(6).ToList();
            return PartialView(values);
        }

        public ActionResult CourseDetail(int id)
        {
            var values = context.Courses.Find(id);
            var reviewList = context.Reviews.Where(x=>x.CourseID==id).ToList();
            ViewBag.review = reviewList;
            return View(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultClassroomPartial()
        {
            var values = context.Classrooms.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultCategoryPartial()
        {
			
			var values = context.Categories.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAboutPartial()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTeacherPartial()
        {
            var value = context.Teachers.OrderByDescending(x=>x.TeacherID).Take(6).ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultFAQPartial()
        {
            var value = context.FAQs.Where(x=>x.Status==true).ToList();
            return PartialView(value);  
        }

        public PartialViewResult DefaultBannerPartial()
        {
            var value = context.Banners.ToList();
            return PartialView(value);
        }
    }
}