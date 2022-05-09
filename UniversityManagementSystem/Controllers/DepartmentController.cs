using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager manager=new DepartmentManager();
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            try
            {
                string code = department.Code;
                string name = department.Name;
                if (!manager.IsCodeAvailable(code))
                {
                    try
                    {
                        if (!manager.IsNameAvailable(name))
                        {
                            manager.Save(department);
                            ViewBag.saveMessage = "Saved Succesfully";
                        }
                    }
                    catch (Exception exception)
                    {


                        ViewBag.nameErrormessage = exception.Message;
                    }
                   
                }
            }
            catch (Exception e)
            {
                ViewBag.codeErrormessage = e.Message;
            }
            return View();
        }

        public ActionResult GetDepartment()
        {
            List<Department> departments = manager.GeDepartments();
            ViewBag.departments = departments;
            return View();
        }
    }
}