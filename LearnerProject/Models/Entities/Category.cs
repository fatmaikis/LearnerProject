using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }
        public List<Course> Course { get; set; }


    }
}