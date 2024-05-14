using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models
{
    public class Classroom
    {
        public int ClassroomID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

       
    }
}