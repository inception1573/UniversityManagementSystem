using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class DepartmentGetway:CommonGetway
    {
        public bool IsCodeAvailable(string  code)
        {
            bool rowvailable = false;
            Quary = "select *from tbl_Department where Code='"+code+"'";
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
            Quary = "select *from tbl_Department where Name='" + name + "'";
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

        public int Save(Department department)
        {
            Quary = "insert into tbl_Department(Code,Name)values(@Code,@Name)";
            Command=new SqlCommand(Quary,Connection);
            Command.Parameters.AddWithValue("@Code", department.Code);
            Command.Parameters.AddWithValue("@Name", department.Name);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Department> GetDepartments()
        {
            Quary = "select *from tbl_Department";
            Command=new SqlCommand(Quary,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Department> departments=new List<Department>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department deparment=new Department();
                    deparment.Id = int.Parse(reader["Id"].ToString());
                    deparment.Code = reader["Code"].ToString();
                    deparment.Name = reader["Name"].ToString();
                    departments.Add(deparment);
                }
                reader.Close();
            }
            Connection.Close();
            return departments;
        }
    }
}