using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.DAL
{
    public class CourseGetway:CommonGetway
    {
        public bool IsCodeAvailable(string code)
        {
            bool rowvailable = false;
            Quary = "select *from tbl_Course where Code='" + code + "'";
            Command = new SqlCommand(Quary, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                rowvailable = true;
            }
            reader.Close();
            Connection.Close();
            return rowvailable;
        }

        public bool IsNameAvailable(string name)
        {
            bool rowvailable = false;
            Quary = "select *from tbl_Course where Name='" + name + "'";
            Command = new SqlCommand(Quary, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                rowvailable = true;
            }
            reader.Close();
            Connection.Close();
            return rowvailable;
        }

        public int Save(Course course)
        {
            Quary = "insert into tbl_Course(Code,Name,Credit,Description,DepartmentId,SemesterId,Statement)values(@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId,@Statement)";
            Command = new SqlCommand(Quary, Connection);
            Command.Parameters.AddWithValue("@Code", course.Code);
            Command.Parameters.AddWithValue("@Name", course.Name);
            Command.Parameters.AddWithValue("@Credit",course.Credit);
            Command.Parameters.AddWithValue("@Description",course.Description);
            Command.Parameters.AddWithValue("@DepartmentId",course.DepartmentId);
            Command.Parameters.AddWithValue("@SemesterId",course.SemesterId);
            Command.Parameters.AddWithValue("@Statement", false);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Semester> GetSemesters()
        {
            Quary = "select *from tbl_Semester";
            Command = new SqlCommand(Quary, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Semester semester = new Semester();
                    semester.Id = int.Parse(reader["Id"].ToString());
                    semester.Name = reader["semesterName"].ToString();
                    semesters.Add(semester);
                }
                reader.Close();
            }
            Connection.Close();
            return semesters;
        }

        public List<Course> GetAllCourses()
        {
            Quary = "select Id,Code,Name,Credit,DepartmentId from tbl_Course";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses=new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course=new Course();
                    course.Id = int.Parse(reader["Id"].ToString());
                    course.Code = reader["Code"].ToString();
                    course.Name = reader["Name"].ToString();
                    course.Credit = double.Parse(reader["Credit"].ToString());
                    course.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                    courses.Add(course);
                }
                reader.Close();
            }
            Connection.Close();
            return courses;
        }

        public void UnassignAllCourse()
        {
            int i = 0;
            Quary = "select *from tbl_Course";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                i++;
                
            }
            reader.Close();
            for (int j=1 ; j<=i; j++)
            {
                string query = "update tbl_Course set statement=0";
                SqlCommand cmd = new SqlCommand(query, Connection);
                cmd.ExecuteNonQuery();
            }
           
            Connection.Close();
        }
    }
}