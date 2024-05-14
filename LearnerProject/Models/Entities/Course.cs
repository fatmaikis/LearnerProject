using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public int? TeacherID { get; set; }
     
        public virtual Teacher Teacher { get; set; }
        public virtual Category Category { get; set; }
        public List<Review> Reviews { get; set; }
        public List<CourseRegister> CourseRegister { get; set; }
        public List<CourseVideo> CourseVideos { get; set; }

    }
}