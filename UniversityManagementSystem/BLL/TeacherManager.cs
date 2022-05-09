using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class TeacherManager
    {
        TeacherGetway getway=new TeacherGetway();
        public bool IsEmailAvailable(string email)
        {
            return getway.IsEmailAvailable(email);
        }

        public int Save(Teacher teacher)
        {
            return getway.Save(teacher);
        }

        public List<Designation> GetDesignations()
        {
            return getway.GetDesignations();
        }
    }
}