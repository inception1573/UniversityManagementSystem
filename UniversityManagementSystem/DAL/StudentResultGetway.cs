using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class StudentResultGetway:CommonGetway
    {
        public List<StudentCourseEnrollView> GetStudentEnrollCourse(int studentId)
        {
            Command = new SqlCommand("procedure_StudentEnrolledCourses", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter=new SqlParameter();
            parameter.ParameterName = "@studentId";
            parameter.Value = studentId;
            Command.Parameters.Add(parameter);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<StudentCourseEnrollView> lisOfStudentCourse=new List<StudentCourseEnrollView>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StudentCourseEnrollView studentCourseEnroll=new StudentCourseEnrollView();
                    studentCourseEnroll.StudentId = int.Parse(reader["StudentId"].ToString());
                    studentCourseEnroll.StudentName = reader["StudentName"].ToString();
                    studentCourseEnroll.Email = reader["Email"].ToString();
                    studentCourseEnroll.CourseId = int.Parse(reader["CoueseId"].ToString());
                    studentCourseEnroll.DepartmentName = reader["DepartmentName"].ToString();
                    studentCourseEnroll.CourseName = reader["CourseName"].ToString();
                    lisOfStudentCourse.Add(studentCourseEnroll);
                }
                reader.Close();
            }
            Connection.Close();
            return lisOfStudentCourse;
        }

        public List<Grade> GetAllGrades()
        {
            Quary = "select *from Grades";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Grade> grades=new List<Grade>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Grade grade=new Grade();
                    grade.Id = int.Parse(reader["Id"].ToString());
                    grade.GradeName = reader["Grade"].ToString();
                    grades.Add(grade);
                }
                reader.Close();
            }
            Connection.Close();
            return grades;
        }

        public int SaveResult(StudentResult result)
        {
            Quary = "insert into StudentResult(StudentId,CourseId,GradeId) values(@StudentId,@CourseId,@GradeId)";
            Command=new SqlCommand(Quary,Connection);
            Command.Parameters.AddWithValue("@StudentId", result.StudentId);
            Command.Parameters.AddWithValue("@CourseId", result.CourseId);
            Command.Parameters.AddWithValue("@GradeId", result.GradeId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<StudentResultView> GetStudentResult(int studentId)
        {
            Command = new SqlCommand("procedure_studentResult", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<StudentResultView> lisOfstudentResult=new List<StudentResultView>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StudentResultView studentResult=new StudentResultView();
                    studentResult.StudentId = int.Parse(reader["StudentId"].ToString());
                    studentResult.CourseCode = reader["CourseCode"].ToString();
                    studentResult.CourseName = reader["CourseName"].ToString();
                    studentResult.Grade = reader["Grade"].ToString();
                    if (studentResult.Grade == "")
                    {
                        studentResult.Grade = "No Graded Yet";
                    }
                    studentResult.RegNo = reader["RegNo"].ToString();
                    studentResult.StudentName = reader["StudentName"].ToString();
                    studentResult.Email = reader["Email"].ToString();
                    studentResult.DepartmentName = reader["Name"].ToString();
                    lisOfstudentResult.Add(studentResult);
                }
                reader.Close();
            }
            Connection.Close();
            return lisOfstudentResult;
        }

        public DataTable GetData(int studentId)
        {
            DataTable dt = new DataTable();
            
                SqlCommand cmd = new SqlCommand("procedure_studentResult", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
      
            return dt;
        }
    }
}