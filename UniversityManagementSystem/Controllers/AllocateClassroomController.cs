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
    public class AllocateClassroomController : Controller
    {
        DepartmentManager de_manager=new DepartmentManager();
        CourseManager cou_manager=new CourseManager();
        AllocateClassroomManager classroom_manager=new AllocateClassroomManager();
        public ActionResult AllocateClass()
        {
            ViewBag.departments = de_manager.GeDepartments();
            ViewBag.courses = cou_manager.GetAllCourses();
            ViewBag.rooms = classroom_manager.GetClassrooms();
            return View();
        }

        [HttpPost]
        public ActionResult AllocateClass(AllocateClassroom classroom, string FromTime, string ToTime)
        {
            ViewBag.departments = de_manager.GeDepartments();
            ViewBag.courses = cou_manager.GetAllCourses();
            ViewBag.rooms = classroom_manager.GetClassrooms();
            List<AllocateClassroom> rooms = classroom_manager.GetAllClassSchedultByDay(classroom.Day,classroom.RoomNo);
            foreach (var time in rooms)
            {
                DateTime PreviousFromTime = time.FromTime;
                DateTime PreviousToTime = time.ToTime;
                DateTime CurrentFromTime = Convert.ToDateTime(FromTime);
                DateTime CurrentToTime = Convert.ToDateTime(ToTime);
                if ((CurrentFromTime > PreviousFromTime && CurrentFromTime < PreviousToTime) ||
                    (CurrentToTime > PreviousFromTime && CurrentToTime < PreviousToTime) ||
                    (PreviousFromTime > CurrentFromTime && PreviousFromTime < CurrentToTime) ||
                    (PreviousToTime > CurrentFromTime && PreviousToTime < CurrentToTime) ||
                    (CurrentFromTime == PreviousFromTime && CurrentToTime == PreviousToTime))
                {
                    ViewBag.TimeExistMessage = "This Time is already booked";
                    return View();
                }
            }
            if (classroom_manager.SetTimeForCourse(classroom) > 0)
            {
                ViewBag.succesMessage = "Time Allocated succesfully";
            }
            return View();
        }

        
    }
}