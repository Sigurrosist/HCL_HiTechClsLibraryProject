using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.DataAccess;

namespace HCL.Business.People
{
    public class MISManager : User
    {
        public MISManager() : base()         {        }
        public Employee Searched_by_id(int id)
        {
            return MIS_DA.Searched_Employee_by_ID(id);
        }
        public void Save_New_Emp(Employee newone)
        {
            MIS_DA.Save_Employee(newone);
        }
        public void Save_New_User(User newone)
        {
            MIS_DA.Save_User(newone);
        }
        public void Update_Emp(Employee emp)
        {
            MIS_DA.Update_Employee(emp);
        }
        public List<Employee> Searched_FirstName(string firstname)
        {
            return MIS_DA.Searched_Employees_by_Fname(firstname);
        }
        public List<Employee> Searched_LastName(string lastname)
        {
            return MIS_DA.Searched_Employees_by_Lname(lastname);
        }
        public List<Employee> Searched_Position(string position)
        {
            return MIS_DA.Searched_Employees_by_Position(position);
        }
        public List<Employee> Searched_Status(string status)
        {
            return MIS_DA.Searched_Employees_by_Status(status);
        }
        public List<User> Searched_Roles(int usercode)
        {
            return MIS_DA.Searched_User_by_Role(usercode);
        }
        public List<Employee> Listed_Employees()
        {
            return MIS_DA.List_Employee();
        }
        public List<User> Listed_Users()
        {
            return MIS_DA.List_User();
        }
        public User Searched_by_userid(string id)
        {
            return MIS_DA.Searched_User_by_ID(id);
        }
        public void Update_Users(User a)
        {
            MIS_DA.Update_User(a);
        }
    }
}
