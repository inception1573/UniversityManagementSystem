using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class CourseAssignGetway:CommonGetway
    {
        public List<Teacher> GetAllTeachersByDepartment(int departmentId)
        {
            Quary = "select Id,Name,CreditToBeTaken from Teachers where DepartmentId='" + departmentId + "'";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Teacher> allTeachersList=new List<Teacher>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Teacher teacher=new Teacher();
                    teacher.Id = int.Parse(reader["Id"].ToString());
                    teacher.Name = reader["Name"].ToString();
                    teacher.Credit_taken = double.Parse(reader["CreditToBeTaken"].ToString());
                    allTeachersList.Add(teacher);
                }
                reader.Close();
            }
            Connection.Close();
            return allTeachersList;
        }

        public TeacherCreditView TotalCreditTakenByTeacher(int departmentId, int teacherId)
        {
            Quary = "select Id,Name,CreditToBeTaken from Teachers where Id='" + teacherId + "'";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            TeacherCreditView teacherCreditView = new TeacherCreditView();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    teacherCreditView.Id = int.Parse(reader["Id"].ToString());
                    teacherCreditView.Name = reader["Name"].ToString();
                    teacherCreditView.Credit_taken = double.Parse(reader["CreditToBeTaken"].ToString());
                }
                reader.Close();
            }
            double totalCredit = 0;
            Quary = "select Credit from CourseTeacher where DepartmentId='" + departmentId + "' and TeacherId='"+teacherId+"'";
            Command = new SqlCommand(Quary, Connection);
            SqlDataReader reader1 = Command.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    totalCredit += double.Parse(reader1["Credit"].ToString());
                }
                reader1.Close();
            }
            teacherCreditView.RemainingCredit = teacherCreditView.Credit_taken - totalCredit;
            Connection.Close();
            return teacherCreditView;
        }

        public int SaveCourseTeacher(CourseAssign courseAssign)
        {
            Quary = "insert into CourseTeacher(DepartmentId,TeacherId,CourseId,Credit) values(@DepartmentId,@TeacherId,@CourseId,@Credit)";
            Command =new SqlCommand(Quary,Connection);
            Command.Parameters.AddWithValue("@DepartmentId", courseAssign.DepartmentId);
            Command.Parameters.AddWithValue("@TeacherId", courseAssign.TeacherId);
            Command.Parameters.AddWithValue("@CourseId", courseAssign.CourseId);
            Command.Parameters.AddWithValue("@Credit", courseAssign.Credit);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Quary = "update tbl_Course set Statement=1 where Id='" + courseAssign.CourseId + "'";
            Command=new SqlCommand(Quary,Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsCourseAssigned(int courseId)
        {
            bool statement = false;
            Quary = "select Statement from tbl_Course where Id='"+courseId+"'";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    statement = bool.Parse(reader["Statement"].ToString());
                }
                reader.Close();
            }
            Connection.Close();
            return statement;
        }

        public List<CourseStatics> GetAllcourseInfo(int departmentId)
        {
            Command=new SqlCommand("pro_viewCourseStatic1",Connection);
            Command.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter=new SqlParameter();
            parameter.ParameterName = "@departmentId";
            parameter.Value = departmentId;
            Command.Parameters.Add(parameter);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
             List<CourseStatics> allCourseInfo=new List<CourseStatics>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   CourseStatics courseStatics=new CourseStatics();
                    courseStatics.Code = reader["Code"].ToString();
                    courseStatics.Name = reader["departmentName"].ToString();
                    courseStatics.Semester = reader["semesterName"].ToString();
                    courseStatics.AssignTo = reader["teacherName"].ToString();
                    if (courseStatics.AssignTo == "")
                    {
                        courseStatics.AssignTo = "Not Assigned yet";
                    }
                    allCourseInfo.Add(courseStatics);
                }
                reader.Close();
            }
            Connection.Close();
            return allCourseInfo;
        }
    }
}