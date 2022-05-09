using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager de_manager = new DepartmentManager();
        StudentManager stu_manager=new StudentManager();
        public ActionResult Register()
        {
            ViewBag.departments = de_manager.GeDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            ViewBag.departments = de_manager.GeDepartments();
            try
            {
                if (stu_manager.isEmailAvailable(student.Email))
                {
                    ViewBag.emailErrormessage = "Email already exist";
                    return View();
                }
                string code = stu_manager.GetDepartmentCode(student.DepartmentId);
                int totalStudent = stu_manager.totalNumberOfStudet()+1;
                DateTime dateTime = DateTime.Now;
                int year = dateTime.Year;
                student.RegNo = code + "-" + year + "-" + totalStudent;
                if (stu_manager.RegisterStudent(student) > 0)
                {
                    ViewBag.registersuccesmessage = "Registration succesful";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
            return View();
        }
    }
}