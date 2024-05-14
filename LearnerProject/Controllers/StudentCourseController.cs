using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentCourseController : Controller
    {
        LearnerContext context=new LearnerContext();
        public ActionResult Index()
        {
			//string studentName = Session["studentName"].ToString();
			//var student = context.Students.Where(x => x.NameSurname ==studentName ).Select(x => x.StudentID).FirstOrDefault();
			//var values = context.CourseRegisters.Where(x => x.StudentID == student).ToList();
			//return View(values);
			
				string studentName = Session["studentName"] as string;
				if (studentName != null)
				{
					var student = context.Students.FirstOrDefault(x => x.NameSurname == studentName);
					if (student != null)
					{
						var values = context.CourseRegisters.Where(x => x.StudentID == student.StudentID).ToList();
						return View(values);
					}
				}
				// Eğer studentName null ise veya öğrenci bulunamazsa yapılacak işlemler
				return RedirectToAction("Index"); // veya başka bir sayfaya yönlendirme yapabilirsiniz
			

		}

		public ActionResult MyCourseList(int id) 
        {
            var values = context.CourseVideos.Where(x => x.CourseID == id).ToList();
            return View(values);
        }
    }
}