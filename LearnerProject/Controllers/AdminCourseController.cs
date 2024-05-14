using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var value = context.Courses.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x=>x.Status==true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            var value = context.Courses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseID);
            value.CourseName = course.CourseName;
            value.CategoryID = course.CategoryID;
            value.ImageUrl = course.ImageUrl;
            value.Price = course.Price;
            value.Description = course.Description;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}