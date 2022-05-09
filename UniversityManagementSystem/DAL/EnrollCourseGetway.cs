using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class EnrollCourseGetway:CommonGetway
    {
        public List<Student> GetAllStudentRegNo()
        {

            Command = new SqlCommand("proc_StudentsWithDepartments", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Student> students=new List<Student>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(reader["Id"].ToString());
                    student.Name = reader["StudentName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.RegNo = reader["Regno"].ToString();
                    student.DepartmentName = reader["DepartmentName"].ToString();
                    students.Add(student);
                }
                reader.Close();
            }
            Connection.Close();
            return students;
        }

        public int AssignCourseStudent(EnrollCourse course)
        {

            Quary = "insert into CourseEnroll(StudentId,CoueseId,CourseEnrollDate)values(@StudentId,@CoueseId,@CourseEnrollDate)";
            Command = new SqlCommand(Quary, Connection);
            Command.Parameters.AddWithValue("@StudentId", course.StudentId);
            Command.Parameters.AddWithValue("@CoueseId", course.CourseId);
            Command.Parameters.AddWithValue("@CourseEnrollDate", course.Date);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsCourseTaken(int studentId, int courseId)
        {
            bool statement = false;
            Quary = "select *from CourseEnroll where StudentId='" + studentId + "' and CoueseId='"+courseId+"'";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    statement = true;
                }
                reader.Close();
            }
            Connection.Close();
            return statement;
        }
    }
}