using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Business.Company;
using HCL.DataAccess;
namespace HCL.Business.People
{
    public class SalesManager : User
    {
        public SalesManager() : base() { }
        public void Save_New_Client(Institute newone)
        {
            Sales_DA.Save_New_Client(newone);
        }
        public void Update_Client(Institute upd)
        {
            Sales_DA.Update_Client(upd);
        }
        public List<Institute> List_Client()
        {
            return Sales_DA.List_Client();
        }
        public List<Institute> Searched_Clients_by_name(string name)
        {
            return Sales_DA.Search_Client_by_Name(name);
        }
        public List<Institute> Searched_Clients_by_credit(double credit)
        {
            return Sales_DA.Search_Client_by_Credit_Left(credit);
        }
        public Institute Searched_Client_by_id(int id)
        {
            return Sales_DA.Search_Client_by_ID(id);
        }
    }
}
