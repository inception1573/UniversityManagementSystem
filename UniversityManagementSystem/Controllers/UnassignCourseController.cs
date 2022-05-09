using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.Controllers
{
    public class UnassignCourseController : Controller
    {
        // GET: UnassignCourse
        public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Index(int? id)
        {
            CourseManager manager=new CourseManager();
            manager.UnassignAllCourse();
            ViewBag.unassign = "All course unassign succesfully";
            return View();
        }
    }
}