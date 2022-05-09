using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseAssignController : Controller
    {
        CourseAssignManager courseAssignManager_manager=new CourseAssignManager();
        CourseManager course_manager=new CourseManager();
        DepartmentManager de_manager=new DepartmentManager();
        public ActionResult Save()
        {
            ViewBag.departments = de_manager.GeDepartments();
            return View();
        }

        public JsonResult GetTeacherByDepartment(int departmentId)
        {
            var teachers = courseAssignManager_manager.GetAllTeachersByDepartment(departmentId);
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTotalCreditTakenByTeacher(int departmentId, int teacherId)
        {
           // var teachers = courseAssignManager_manager.GetAllTeachersByDepartment(departmentId);
            //var teacher = teachers.Where(a => a.Id == teacherId).ToList();
            var teacher = courseAssignManager_manager.TotalCreditTakenByTeacher(departmentId, teacherId); 
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCourseCodeByDepartment(int departmentId)
        {
            var courses = course_manager.GetAllCourses();
            var course = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(course, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCourseNameCreditByDepartment(int courseId)
        {
            var courses = course_manager.GetAllCourses();
            var course = courses.Where(a => a.Id == courseId).ToList();
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(CourseAssign courseAssign)
        {
          
       
            if (courseAssign.RemainingCredit - courseAssign.Credit < 0)
            {
                //return JavaScript("window.alert('HELLO');");          
            }
            if (courseAssignManager_manager.IsCourseAssigned(courseAssign.CourseId))
            {
                ViewBag.courseAssignErrormessage = "Selected course is already assigned";
                return View();
            }
           
            if (courseAssignManager_manager.SaveCourseTeacher(courseAssign) > 0)
            {
                ViewBag.savesuccesMessage = "Course assign successfully completed";
            }
            return View();
        }

       
    }
}