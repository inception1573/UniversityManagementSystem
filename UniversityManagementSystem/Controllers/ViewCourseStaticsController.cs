using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.Controllers
{
    public class ViewCourseStaticsController : Controller
    {
        DepartmentManager manager=new DepartmentManager();
        CourseAssignManager courseAssignManager=new CourseAssignManager();
        public ActionResult GetAllCourseInfoByDepartment()
        {
            ViewBag.departments = manager.GeDepartments();
            return View();
        }

        public JsonResult ViewAllCourseInfo(int departmentId)
        {
            var courseInfo = courseAssignManager.GetAllcourseInfo(departmentId);
            return Json(courseInfo, JsonRequestBehavior.AllowGet);
        }
    }
}