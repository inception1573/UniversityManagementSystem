using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseAssignManager
    {
        CourseAssignGetway getway=new CourseAssignGetway();
        public List<Teacher> GetAllTeachersByDepartment(int departmentId)
        {
            return getway.GetAllTeachersByDepartment(departmentId);
        }

        public TeacherCreditView TotalCreditTakenByTeacher(int departmentId, int teacherId)
        {
            return getway.TotalCreditTakenByTeacher(departmentId,teacherId);
        }

        public int SaveCourseTeacher(CourseAssign courseAssign)
        {
            return getway.SaveCourseTeacher(courseAssign);
        }

        public bool IsCourseAssigned(int courseId)
        {
            return getway.IsCourseAssigned(courseId);
        }

        public List<CourseStatics> GetAllcourseInfo(int departmentId)
        {
            return getway.GetAllcourseInfo(departmentId);
        }

    }
}