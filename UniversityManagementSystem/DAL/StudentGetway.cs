using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class StudentGetway:CommonGetway
    {
        public int RegisterStudent(Student student)
        {
            Quary = "insert into Students(RegNo,Name,Email,ContactNo,Date,Address,DepartmentId)values(@RegNo,@Name,@Email,@ContactNo,@Date,@Address,@DepartmentId)";
            Command = new SqlCommand(Quary, Connection);
            Command.Parameters.AddWithValue("@RegNo", student.RegNo);
            Command.Parameters.AddWithValue("@Name", student.Name);
            Command.Parameters.AddWithValue("@Email", student.Email);
            Command.Parameters.AddWithValue("@ContactNo", student.ContactNo);
            Command.Parameters.AddWithValue("@Date", student.RegDate);
            Command.Parameters.AddWithValue("@Address", student.Address);
            Command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public string GetDepartmentCode(int departmentId)
        {
            string code = null;
            Quary = "select Code from tbl_Department where Id='" + departmentId + "'";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    code = reader["Code"].ToString();
                }
                
            }
            reader.Close();
            Connection.Close();
            return code;
        }

        public int totalNumberOfStudet()
        {
            int totalStudent = 1;
            Quary = "SELECT TOP 1 Id FROM Students ORDER BY Id DESC";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    totalStudent = int.Parse(reader["Id"].ToString());
                }
                
            }
            reader.Close();
            Connection.Close();
            return totalStudent;
        }

        public bool isEmailAvailable(string email)
        {
            Quary = "select *from Students where Email='" + email + "'";
            Command = new SqlCommand(Quary, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool statement = false;
            if (reader.HasRows)
            {
                statement = true;
            }
            reader.Close();
            Connection.Close();
            return statement;
        }
    }
}