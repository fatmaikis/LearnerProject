using LearnerProject.Models;
using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class ClassroomController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var value = context.Classrooms.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddClassroom()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult AddClassroom(Classroom classroom)
        {
            context.Classrooms.Add(classroom);
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult DeleteClassroom(int id)
        {
            var value = context.Classrooms.Find(id);
            context.Classrooms.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateClassroom(int id)
        {
            var value = context.Classrooms.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateClassroom(Classroom classroom)
        {
            var value = context.Classrooms.Find(classroom.ClassroomID);
            value.ClassroomID = classroom.ClassroomID;  
            value.Name= classroom.Name; 
            value.Description= classroom.Description;
            context.SaveChanges();  
            return RedirectToAction("Index");
        }

	}
}