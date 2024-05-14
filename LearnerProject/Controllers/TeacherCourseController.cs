using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class TeacherCourseController : Controller
    {
       LearnerContext context=new LearnerContext();

        public ActionResult Index()
        {
            string name = Session["teacherName"].ToString();
            var values = context.Courses.Where(x => x.Teacher.NameSurname == name).ToList();
            return View(values);
        }
        public ActionResult DeleteCourse(int id)
        {
            var values = context.Courses.Find(id);
            context.Courses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
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
            string name = Session["teacherName"].ToString();
            course.TeacherID = context.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherID).FirstOrDefault();
            context.Courses.Add(course);
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
            string name = Session["teacherName"].ToString();

            value.TeacherID = context.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherID).FirstOrDefault();

            value.CourseName=course.CourseName;
            value.CategoryID = course.CategoryID;
            value.Price=course.Price;
            value.Description=course.Description;
            value.ImageUrl=course.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}