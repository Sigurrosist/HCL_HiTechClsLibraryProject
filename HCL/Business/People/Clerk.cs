using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.DataAccess;
using HCL.Business.Company;
using HCL.Business.Order;

namespace HCL.Business.People
{
    public class Clerk : User
    {
        public Clerk() : base()
        {

        }
        public void Write_Added_Items_List(string itemlist)
        {
            Order_DA.Write_Adding_Items_List(itemlist);
        }
        public string Read_Added_Items_List()
        {
            return Order_DA.Read_Adding_Items_List();
        }
        public void Bring_New_Order_Status()
        {
            Order_DA.Bring_New_Order_Status();
        }
        public List<Institute> List_Client()
        {
            return Order_DA.List_Client();
        }
        public void Refresh_Order_Status(string target, string replace)
        {
            Order_DA.Refresh_Order_Status(target, replace);
        }
        public void Add_Item_List(string itemlist, string tps, string tvq, string subtotal, string total)
        {
            Order_DA.Add_Item_List(itemlist, tps, tvq, subtotal, total);
        }
        public List<string> List_OrderClerkID()
        {
            return Order_DA.List_OrderClerkID();
        }
        public List<string> Read_Order_Status()
        {
            return Order_DA.Read_Order_Status();
        }
        public string Order_ID_Generator()
        {
            return Order_DA.Order_ID_Generator();
        }
        public void Save_New_Order(Order_Client one)
        {
            Order_DA.Save_New_Order(one);
        }
        public List<Order_Client> Listed_Orders()
        {
            return Order_DA.List_Orders();
        }
        public Order_Client Searched_Order_by_ID(string id)
        {
            return Order_DA.Search_Order_by_ID(id);
        }
        public void Open_New_Order_Status ()
        {
            Order_DA.Open_Order();
        }
        public void Update_Order(Order_Client a)
        {
            Order_DA.Update_Order(a);
        }
        public bool Check_Credit(string c_id, string total)
        {
            return Order_DA.Check_Credit(c_id, total);
        }
        public void Update_Item_Quantity(string itemid, int addnumber)
        {
            Order_DA.Update_Item_Quantity(itemid, addnumber);
        }
        public void Update_Client_Credit(string clientid, double addcredit)
        {
            Order_DA.Update_Client_Credit(clientid, addcredit);
        }
        public List<string> Order_ID_List()
        {
            return Order_DA.Order_ID_List();
        }
        public List<Order_Client> Search_Orders_by_ClientID(string clientid)
        {
            return Order_DA.Search_Orders_by_ClientID(clientid);
        }
        public List<Order_Client> Searched_Orders_by_Included_Item(string itemid)
        {
            return Order_DA.Searched_Orders_by_Included_Item(itemid);
        }
        public List<Order_Client> Searched_Orders_by_Order_Method(string method)
        {
            return Order_DA.Searched_Orders_by_Order_Method(method);
        }
        public List<Order_Client> Searched_Orders_by_Payment_Status(string payment_status)
        {
            return Order_DA.Searched_Orders_by_Payment_Status(payment_status);
        }
        public List<Order_Client> Searched_Orders_by_Shipping_Date(string ship_date)
        {
            return Order_DA.Searched_Orders_by_Shipping_Date(ship_date);
        }
        public List<Order_Client> Searched_Orders_by_Expected_Date(string expect_date)
        {
            return Order_DA.Searched_Orders_by_Expected_Date(expect_date);
        }
        public List<Order_Client> Searched_Orders_by_Order_Clerk_ID(string orderclerkid)
        {
            return Order_DA.Searched_Orders_by_Order_Clerk_ID(orderclerkid);
        }
        public bool Delete_Order(string itemid)
        {
            return Order_DA.Delete_Order(itemid);
        }
        //a.Void Save_Order_Client_Information(Order_Client order)
        //b.Void Update_Order_Client_Information(int ocid)
        //c.Void Cancel_Order_Client_Information(Order_Client order)
        //d.List<Order_Client> List_Order_Client_Information()
        //e.List<Order_Client> Searched_Order_Client_By_Client_ID(int cid)
        //f.List<Order_Client> Searched_Order_Client_By_Item_ID(int iid)
        //g.Order_Client Searched_Order_Client_By_Order_ID(int oid)
        //h.Order_Client Searched_Order_Client_By_Clerk_ID(int clerkid)
        //i.Order_Client Searched_Order_Client_By_Clerk_Fname(string cfname)
        //j.List<Order_Client> Searched_Client_By_Payment_Status(string payment_status)

    }
}
