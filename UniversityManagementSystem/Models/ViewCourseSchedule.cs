using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ViewCourseSchedule
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string AllSchedule { get; set; }
        
    }
}