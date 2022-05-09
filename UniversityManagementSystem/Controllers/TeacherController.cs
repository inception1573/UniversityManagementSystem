using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager de_manager = new DepartmentManager();
        TeacherManager te_manager=new TeacherManager();
        public ActionResult Save()
        {
            ViewBag.departments = de_manager.GeDepartments();
            ViewBag.designations = te_manager.GetDesignations();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            ViewBag.departments = de_manager.GeDepartments();
            ViewBag.designations = te_manager.GetDesignations();
            try
            {
                if (te_manager.IsEmailAvailable(teacher.Email))
                {
                    ViewBag.emailErrormessage = "Email already exist";
                    return View();
                }
                if (teacher.Credit_taken < 0)
                {
                    ViewBag.nonnegationErrormessage = "Credit to taken can not be negative.";
                    return View();
                }
                if (te_manager.Save(teacher) > 0)
                {
                    ViewBag.succesmessage = "Saved successfully";
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