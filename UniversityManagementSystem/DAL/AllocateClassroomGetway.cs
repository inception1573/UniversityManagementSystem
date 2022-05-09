using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class AllocateClassroomGetway:CommonGetway
    {
        public List<string> GetClassrooms()
        {
            Quary = "select RoomNo from RoomNo";
            Command = new SqlCommand(Quary, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<string> rooms = new List<string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string roomNo = reader["RoomNo"].ToString();
                    rooms.Add(roomNo);
                }
                reader.Close();
            }
            Connection.Close();
            return rooms;
        }

        public int SetTimeForCourse(AllocateClassroom room)
        {
            Quary = "insert into AllocateClassRoom(DepartmentId,CourseId,RoomNo,Day,FromTime,ToTime)values(@DepartmentId,@CourseId,@RoomNo,@Day,@FromTime,@ToTime)";
            Command=new SqlCommand(Quary,Connection);
            Command.Parameters.AddWithValue("@DepartmentId", room.DepartmentId);
            Command.Parameters.AddWithValue("@CourseId", room.CourseId);
            Command.Parameters.AddWithValue("@RoomNo", room.RoomNo);
            Command.Parameters.AddWithValue("@Day", room.Day);
            Command.Parameters.AddWithValue("@FromTime", room.FromTime);
            Command.Parameters.AddWithValue("@ToTime", room.ToTime);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<AllocateClassroom> GetAllClassSchedultByDay(string day,string roomNo)
        {
            Quary = "select *from AllocateClassRoom where Day='" + day + "' and RoomNo='"+roomNo+"'";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<AllocateClassroom> rooms=new List<AllocateClassroom>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                        AllocateClassroom room=new AllocateClassroom();
                        room.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                        room.CourseId = int.Parse(reader["CourseId"].ToString());
                        room.RoomNo = reader["RoomNo"].ToString();
                        room.Day = reader["Day"].ToString();
                        room.FromTime = DateTime.Parse(reader["FromTime"].ToString());
                        room.ToTime =DateTime.Parse(reader["ToTime"].ToString());
                        rooms.Add(room);
                    
                   
                }
                reader.Close();
            }
            Connection.Close();
            return rooms;
        }

        public List<ViewCourseSchedule> GetCourseScheduleByDepartment(int departmentId)
        {
            Quary = "select DISTINCT c.Id,c.Code,c.Name from AllocateClassRoom a join tbl_Course c on a.CourseId=c.Id where a.DepartmentId='" + departmentId + "'";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses=new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();
                    course.Id = int.Parse(reader["Id"].ToString());
                    course.Code = reader["Code"].ToString();
                    course.Name = reader["Name"].ToString();
                    courses.Add(course);
                }
                reader.Close();
            }
            List<ViewCourseSchedule> schedules=new List<ViewCourseSchedule>();
            foreach (var cs in courses)
            {
                string concate="";
                Quary = "select RoomNo,Day,FromTime,ToTime from AllocateClassRoom where CourseId='"+cs.Id+"'";
                Command=new SqlCommand(Quary,Connection);
   
                SqlDataReader reader1 = Command.ExecuteReader();
                while (reader1.Read())
                {
                     concate += "R.No:" + reader1["RoomNo"]+","+reader1["Day"]+","+reader1["FromTime"]+"-"+reader1["ToTime"]+"\n";
                }
                ViewCourseSchedule schedule=new ViewCourseSchedule();
                schedule.Name = cs.Name;
                schedule.CourseCode = cs.Code;
                schedule.AllSchedule = concate;
                schedules.Add(schedule);
                reader1.Close();
            }
            Connection.Close();
            return schedules;
        }
    }
}