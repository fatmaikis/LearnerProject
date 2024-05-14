using LearnerProject.Models;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentController : Controller
    {
		LearnerContext context = new LearnerContext();
		public ActionResult Index()
		{
			var value = context.Students.ToList();
			return View(value);
		}

		[HttpGet]
		public ActionResult AddStudent()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddStudent(Student student)
		{
			context.Students.Add(student);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteStudent(int id)
		{
			var value = context.Students.Find(id);
			context.Students.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult UpdateStudent(int id)
		{
			var value = context.Students.Find(id);
			return View(value);

		}
		[HttpPost]
		public ActionResult UpdateStudent(Student student)
		{
			var value = context.Students.Find(student.StudentID);
			value.StudentID = student.StudentID;
			value.NameSurname = student.NameSurname;
			value.UserName = student.UserName;
			value.Password = student.Password;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}