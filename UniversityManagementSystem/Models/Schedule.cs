using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Schedule
    {
        public string RoomNo { get; set; }
        public string Day { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
    }
}