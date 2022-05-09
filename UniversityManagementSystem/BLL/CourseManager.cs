using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseManager
    {
        CourseGetway getway=new CourseGetway();
        public bool IsCodeAvailable(string code)
        {
            return getway.IsCodeAvailable(code);
        }
        public bool IsNameAvailable(string name)
        {
            return getway.IsNameAvailable(name);
        }
        public int Save(Course course)
        {
            return getway.Save((course));
        }

        public List<Semester> GetSemesters()
        {
            return getway.GetSemesters();
        }

        public List<Course> GetAllCourses()
        {
            return getway.GetAllCourses();
        }

        public void UnassignAllCourse()
        {
            getway.UnassignAllCourse();
        }
    }
}