using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class StudentResultView
    {
        public int StudentId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Grade { get; set; }
        public string RegNo { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
    }
}