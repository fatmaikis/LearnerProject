using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class CourseVideo
    {
        public int CourseVideoID { get; set; }
        public int CourseID { get; set; }
        public virtual Course Courses { get; set; }
        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }

    }
}