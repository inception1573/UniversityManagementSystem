using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AllocateClassroom
    {
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }

    }
}