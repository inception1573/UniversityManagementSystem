using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewCourseScheduleController : Controller
    {
        DepartmentManager de_manager = new DepartmentManager();
        AllocateClassroomManager classroom_manager = new AllocateClassroomManager();
        public ActionResult Index()
        {
            ViewBag.departments = de_manager.GeDepartments();
            return View();
        }
        public JsonResult GetScheduleByDepartment(int departmentId)
        {
            List<ViewCourseSchedule> schedules = classroom_manager.GetCourseScheduleByDepartment(departmentId);
           

            return Json(schedules, JsonRequestBehavior.AllowGet);
        }
    }
}