using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class StudentResultManager
    {
        StudentResultGetway getway=new StudentResultGetway();
        public List<StudentCourseEnrollView> GetStudentEnrollCourse(int studentId)
        {
            return getway.GetStudentEnrollCourse(studentId);
        }

        public List<Grade> GetAllGrades()
        {
            return getway.GetAllGrades();
        }

        public int SaveResult(StudentResult result)
        {
            return getway.SaveResult(result);
        }

        public List<StudentResultView> GetStudentResult(int studentId)
        {
            return getway.GetStudentResult(studentId);
        }

        public DataTable GetData(int studentId)
        {
            return getway.GetData(studentId);
        }
    }
}