using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DepartmentManager
    {
        DepartmentGetway getway=new DepartmentGetway();
        public bool IsCodeAvailable(string code)
        {
            int length = code.Length;
            if (length < 2 || length > 7)
            {
                throw new Exception("Code length must be two to seven character");
            }
            if (getway.IsCodeAvailable(code))
            {
                throw new Exception("Code Already Availavle");
            }
            return getway.IsCodeAvailable(code);
        }
        public bool IsNameAvailable(string name)
        {
            if (getway.IsNameAvailable(name))
            {
                throw new Exception("Name Already Availavle");
            }
            return getway.IsCodeAvailable(name);
        }

        public int Save(Department department)
        {
           return  getway.Save((department));
        }

        public List<Department> GeDepartments()
        {
            return getway.GetDepartments();
        }
    }
}