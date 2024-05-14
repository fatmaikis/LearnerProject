using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }  
        public double ReviewValue {  get; set; }

        public string Comment { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

    }
}