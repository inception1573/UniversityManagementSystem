using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class AllocateClassroomManager
    {
        AllocateClassroomGetway getway=new AllocateClassroomGetway(); 
        public List<string> GetClassrooms()
        {
            return getway.GetClassrooms();
        }

        public int SetTimeForCourse(AllocateClassroom room)
        {
            return getway.SetTimeForCourse(room);
        }

        public List<AllocateClassroom> GetAllClassSchedultByDay(string day,string roomNo)
        {
            return getway.GetAllClassSchedultByDay(day,roomNo);
        }

        public List<ViewCourseSchedule> GetCourseScheduleByDepartment(int departmentId)
        {
            return getway.GetCourseScheduleByDepartment(departmentId);
        }
    }
}