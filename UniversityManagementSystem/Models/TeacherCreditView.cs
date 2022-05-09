using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class TeacherCreditView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Credit_taken { get; set; }
        public double RemainingCredit { get; set; }
    }
}