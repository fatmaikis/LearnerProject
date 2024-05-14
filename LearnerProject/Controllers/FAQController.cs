using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class FAQController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var value = context.FAQs.Where(x=>x.Status==true).ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddFAQS()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFAQS(FAQ faq)
        {
            faq.Status = true;
            context.FAQs.Add(faq);
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult DeleteFAQS(int id)
        {
            var value = context.FAQs.Find(id);
			value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFAQS(int id)
        {
            var value = context.FAQs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFAQS(FAQ faq)
        {
            var value = context.FAQs.Find(faq.FAQID);
            value.FAQID = faq.FAQID;
            value.Question = faq.Question;
            value.Answer = faq.Answer;
            value.ImageUrl = faq.ImageUrl;  
            value.Status = faq.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}