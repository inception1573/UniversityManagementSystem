using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class EnrollCourseManager
    {
        EnrollCourseGetway getway=new EnrollCourseGetway();
        public List<Student> GetAllStudentRegNo()
        {
            return getway.GetAllStudentRegNo();
        }

        public int AssignCourseToStudent(EnrollCourse course)
        {
           return getway.AssignCourseStudent(course);
        }

        public bool IsCourseTaken(int studentId, int courseId)
        {
            return getway.IsCourseTaken(studentId, courseId);
        }
    }
}