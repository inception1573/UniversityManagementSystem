using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class EnrollCourseController : Controller
    {
        // GET: EnrollCourse
        EnrollCourseManager manager=new EnrollCourseManager();
        CourseManager cour_manager=new CourseManager();
        public ActionResult Enroll()
        {
            ViewBag.studentRegnos = manager.GetAllStudentRegNo();
            ViewBag.Courses = cour_manager.GetAllCourses();
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(EnrollCourse course)
        {
            ViewBag.studentRegnos = manager.GetAllStudentRegNo();
            ViewBag.Courses = cour_manager.GetAllCourses();
            if (manager.IsCourseTaken(course.StudentId,course.CourseId))
            {
                ViewBag.Erroemessage = "This course already taken";
                return View();
            }
            if (manager.AssignCourseToStudent(course) > 0)
            {
                ViewBag.successmessage = "Succesfully enroll course to student";
            }
            return View();
        }

        public JsonResult GetStudetnInfo(int studentId)
        {
            var students = manager.GetAllStudentRegNo();
            var student = students.Where(a => a.Id == studentId).ToList();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

    }
}