using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseManager manager=new CourseManager();
        DepartmentManager de_manager=new DepartmentManager();
        public ActionResult Save()
        {
            ViewBag.semesters = manager.GetSemesters();
            ViewBag.departments = de_manager.GeDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {
            ViewBag.semesters = manager.GetSemesters();
            ViewBag.departments = de_manager.GeDepartments();
            try
            {
                string code = course.Code;
                string name = course.Name;
                double credit = course.Credit;
                if (code.Length<5)
                {
                    ViewBag.codeErrormessage = "Code must be atleast five character long";
                    return View();
                }
                if (manager.IsCodeAvailable(code))
                {
                    ViewBag.codeErrormessage = "Code already exist";
                    return View();
                }
                if (manager.IsNameAvailable(name))
                {
                    ViewBag.nameErrormessage = "Name already exist";
                    return View();
                }
                if (credit < .5 || credit > 5)
                {
                    ViewBag.creditErrormessage = "Credit must be .5 to 5.0";
                    return View();
                }
                manager.Save(course);
                ViewBag.saveMessage = "Saved successfully";
            }
            catch (Exception e)
            {
                ViewBag.codeErrormessage = e.Message;
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}