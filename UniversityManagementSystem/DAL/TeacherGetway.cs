using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class TeacherGetway:CommonGetway
    {
        public bool IsEmailAvailable(string email)
        {
            Quary = "select *from Teachers where Email='"+email+"'";
            Command=new SqlCommand(Quary,Connection);
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
        public int Save(Teacher teacher)
        {
            Quary = "insert into Teachers(Name,Address,Email,ContactNo,DesignationId,DepartmentId,CreditToBeTaken)values(@Name,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@CreditToBeTaken)";
            Command = new SqlCommand(Quary, Connection);
            Command.Parameters.AddWithValue("@Name", teacher.Name);
            Command.Parameters.AddWithValue("@Address", teacher.Address);
            Command.Parameters.AddWithValue("@Email", teacher.Email);
            Command.Parameters.AddWithValue("@ContactNo", teacher.Contact_no);
            Command.Parameters.AddWithValue("@DesignationId", teacher.DesignationId);
            Command.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
            Command.Parameters.AddWithValue("@CreditToBeTaken", teacher.Credit_taken);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Designation> GetDesignations()
        {
            Quary = "select *from Designations";
            Command = new SqlCommand(Quary, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Designation designation = new Designation();
                    designation.Id = int.Parse(reader["Id"].ToString());
                    designation.Name = reader["Name"].ToString();
                    designations.Add(designation);
                }
                reader.Close();
            }
            Connection.Close();
            return designations;
        }
    }
}