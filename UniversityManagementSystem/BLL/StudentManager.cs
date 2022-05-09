using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class StudentManager
    {
        StudentGetway getway=new StudentGetway();
        public int RegisterStudent(Student student)
        {
            return getway.RegisterStudent(student);
        }

        public string GetDepartmentCode(int departmentId)
        {
            return getway.GetDepartmentCode(departmentId);
        }

        public int totalNumberOfStudet()
        {
           return getway.totalNumberOfStudet();
        }

        public bool isEmailAvailable(string email)
        {
            return getway.isEmailAvailable(email);
        }
    }
}