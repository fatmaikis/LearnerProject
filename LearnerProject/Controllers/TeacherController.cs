using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class TeacherController : Controller
    {
		LearnerContext context = new LearnerContext();
		public ActionResult Index()
		{
			var value = context.Teachers.ToList();
			return View(value);
		}

		[HttpGet]
		public ActionResult AddTeacher()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddTeacher(Teacher teacher)
		{
			context.Teachers.Add(teacher);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteTeacher(int id)
		{
			var value = context.Teachers.Find(id);
			context.Teachers.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult UpdateTeacher(int id)
		{
			var value = context.Teachers.Find(id);
			return View(value);

		}
		[HttpPost]
		public ActionResult UpdateTeacher(Teacher teacher)
		{
			var value = context.Teachers.Find(teacher.TeacherID);
			value.TeacherID = teacher.TeacherID;
			value.NameSurname = teacher.NameSurname;
			value.UserName = teacher.UserName;
			value.Password = teacher.Password;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}