using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseAssign
    {
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public double Credit { get; set; }
        public double RemainingCredit { get; set; }
    }
}