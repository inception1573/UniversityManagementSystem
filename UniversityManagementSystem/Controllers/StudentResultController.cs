using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentResultController : Controller
    {
        EnrollCourseManager manager = new EnrollCourseManager();
        StudentResultManager resultManager=new StudentResultManager();
        public ActionResult SaveStudentResult()
        {
            ViewBag.studentRegnos = manager.GetAllStudentRegNo();
            ViewBag.grades = resultManager.GetAllGrades();
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudentResult(StudentResult result)
        {
            ViewBag.studentRegnos = manager.GetAllStudentRegNo();
            ViewBag.grades = resultManager.GetAllGrades();
            if (resultManager.SaveResult(result) > 0)
            {
                ViewBag.succesmessage = "Result Saved Succesfully";
            }
            return View();
        }
        public JsonResult StudentInfoWithEnrollCourse(int studentId)
        {
            var studentEnrollCourse = resultManager.GetStudentEnrollCourse(studentId);
            return Json(studentEnrollCourse, JsonRequestBehavior.AllowGet);
        }
    }
}