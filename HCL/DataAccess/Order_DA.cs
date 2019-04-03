using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Business.Company;
using HCL.Business.People;
using HCL.Business.Order;
using HCL.Business.Items;
using System.Diagnostics;

namespace HCL.DataAccess
{
    class Order_DA
    {
        static private string activedir = @"C:\";
        static private string folderlocation = Path.Combine(activedir, @"JooyeonMok_HCL_FinalProject\");
        static private string publisherlocation = Path.Combine(folderlocation, "Publisher.dat");
        static private string booklocation = Path.Combine(folderlocation, "Book.dat");
        static private string softwarelocation = Path.Combine(folderlocation, "Software.dat");
        static private string tempfilelocation = Path.Combine(folderlocation, "Temp_Data.dat");
        static private string deletedorderlocation = Path.Combine(folderlocation, "Deleted_by_OrderClerk.txt");
        static private string orderlocation = Path.Combine(folderlocation, "Order.dat");
        static private string neworderstatuslocation = Path.Combine(folderlocation, "Order_Status.txt");
        static private string orderstatuslocation = Path.Combine(folderlocation, "OrderStatus.txt");
        static private string clientdatalocation = Path.Combine(folderlocation, "Client.dat");
        static private string userdatalocaion = Path.Combine(folderlocation, "User.dat");
        static private string addingitemtemp = Path.Combine(folderlocation, "Adding_Items_List.dat");
        
        static public void Bring_New_Order_Status()
        {
            if (File.Exists(neworderstatuslocation))
            {
                File.Delete(neworderstatuslocation);
            }
            File.Copy(orderstatuslocation, neworderstatuslocation);
        }
        static public List<string> Read_Order_Status()
        {
            List<string> read = new List<string>();
            using (StreamReader re = new StreamReader(neworderstatuslocation))
            {
                string lines = re.ReadLine();
                while(lines != null)
                {
                    read.Add(lines);
                    lines = re.ReadLine();
                }
            }
            return read;
        }
        static public List<Institute> List_Client()
        {
            List<Institute> list = new List<Institute>();
            Institute newone;
            using (StreamReader read = new StreamReader(clientdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    newone = new Institute();
                    string[] col = lines.Split('|');
                    newone.Id = col[0];
                    newone.Name = col[1];
                    newone.Street_Number = col[2];
                    newone.Street_Name = col[3];
                    newone.City = col[4];
                    newone.PostalCode = col[5];
                    newone.Phone = col[6];
                    newone.Fax = col[7];
                    newone.Email = col[8];
                    newone.Person_in_Charge = col[9];
                    newone.Credit_Left = col[10];
                    newone.Credit_Contract = col[11];
                    newone.Status = col[12];
                    list.Add(newone);
                    lines = read.ReadLine();
                }
            }
            return list;
        }
        static public void Refresh_Order_Status(string target, string replace)
        {
            if(File.Exists(neworderstatuslocation))
            { 
                using (StreamReader re = new StreamReader(neworderstatuslocation))
                {
                    string lines = re.ReadLine();
                    while (lines != null)
                    {
                        if (lines.Contains(target))
                        {
                            lines = replace;
                        }
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(lines);
                        }
                        lines = re.ReadLine();
                    }
                }
                File.Delete(neworderstatuslocation);
                File.Move(tempfilelocation, neworderstatuslocation);
            }
        }
        static public void Add_Item_List(string itemlist, string tps, string tvq, string subtotal, string total)
        {
                        using (StreamWriter wr = new StreamWriter(neworderstatuslocation, true))
                        {
                            string[] field = itemlist.Split('+');
                            foreach (string t in field)
                            {
                                string[] col = t.Split(',');
                                wr.WriteLine("-" + col[0] + "\t\t" + col[1] + "\t" + col[2]);
                            }
                        }
                        using (StreamWriter wr = new StreamWriter(neworderstatuslocation, true))
                        {
                            wr.WriteLine("---------------------------------------------------------------------------");
                            wr.WriteLine("-SubTotal                  :         " + "CAD " + subtotal);
                            wr.WriteLine("-T.P.S                        :         " + "CAD " + tps);
                            wr.WriteLine("-T.V.Q                        :         " + "CAD " + tvq);
                            wr.WriteLine("---------------------------------------------------------------------------");
                            wr.WriteLine("-Total                         :         " + "CAD " + total);
                        }
        }
        static public List<string> List_OrderClerkID()
        {
            List<string> clerks = new List<string>();
            using (StreamReader read = new StreamReader(userdatalocaion))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[2] == "4")
                    {
                        clerks.Add(col[0]);
                    }
                    lines = read.ReadLine();
                }
            }
            return clerks;
        }
        static public void Write_Adding_Items_List(string addeditems)
        {
            using (StreamWriter wr = new StreamWriter(addingitemtemp))
            {
                wr.WriteLine(addeditems);
            }
        }
        static public string Read_Adding_Items_List()
        {
            string line = "";
            if (File.Exists(addingitemtemp))
            {
                using (StreamReader re = new StreamReader(addingitemtemp))
                {
                    line = re.ReadLine();
                }
            }
            return line;
        }
        static public string Order_ID_Generator()
        {
            int a = 0;
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while(lines != null)
                {
                    string[] col = lines.Split('|');
                    a = Convert.ToInt32(col[0]);
                    lines = re.ReadLine();
                }
                a += 1;
            }
            return a.ToString();
        }
        static public void Save_New_Order(Order_Client one)
        {
            using (StreamWriter wr = new StreamWriter(orderlocation, true))
            {
                wr.WriteLine(one.OrderID + "|" + one.ClientID + "|" +one.ItemList + "|" +one.OrderMethod + "|" +one.Payment_status + "|" +one.ShippingDate + "|" +one.ExpectedDate + "|" +one.OrderClerkID);
            }
        }
        static public List<Order_Client> List_Orders()
        {
            List<Order_Client> list = new List<Order_Client>();
            Order_Client a;

            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while(lines != null)
                { 
                    string[] col = lines.Split('|');
                    a = new Order_Client();
                    a.OrderID = col[0];
                    a.ClientID = col[1];
                    a.ItemList = col[2];
                    a.OrderMethod = col[3];
                    a.Payment_status = col[4];
                    a.ShippingDate = col[5];
                    a.ExpectedDate = col[6];
                    a.OrderClerkID = col[7];
                    list.Add(a);
                    lines = re.ReadLine();
                }
            }
                return list;
        }
        static public Order_Client Search_Order_by_ID(string id)
        {
            Order_Client a = new Order_Client();
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while(lines != null)
                {
                    string[] col = lines.Split('|');
                    if (id == col[0])
                    {
                        a.OrderID = col[0];
                        a.ClientID = col[1];
                        a.ItemList = col[2];
                        a.OrderMethod = col[3];
                        a.Payment_status = col[4];
                        a.ShippingDate = col[5];
                        a.ExpectedDate = col[6];
                        a.OrderClerkID = col[7];
                        break;
                    }
                    lines = re.ReadLine();
                }
            }
            return a;
        }
        static public void Open_Order()
        {
            Process.Start(neworderstatuslocation);
        }
        static public void Update_Order(Order_Client order)
        {
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while(lines!= null)
                {
                    string[] col = lines.Split('|');
                    if(col[0] == order.OrderID)
                    {
                        lines = order.OrderID + "|" + order.ClientID + "|" + order.ItemList + "|" + 
                                order.OrderMethod + "|" + order.Payment_status + "|" + 
                                order.ShippingDate + "|" + order.ExpectedDate + "|" + order.OrderClerkID;
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = re.ReadLine();
                }
            }
            File.Delete(orderlocation);
            File.Move(tempfilelocation, orderlocation);
        }
        static public bool Check_Credit(string c_id, string total)
        {
            bool credit_ok = false;
            using (StreamReader re = new StreamReader(clientdatalocation))
            {
                string lines = re.ReadLine();
                while(lines != null)
                {
                    string[] col = lines.Split('|');
                    if(c_id == col[0])
                    {
                        if(Convert.ToDouble(col[10]) >= Convert.ToDouble(total))
                        {
                            credit_ok = true;
                        }
                        else
                        {
                            credit_ok = false;
                        }
                        break;
                    }
                    lines = re.ReadLine();
                }
            }
            return credit_ok;
        }
        static public void Update_Item_Quantity(string itemid, int addnumber)
        {
            InventoryController wang = new InventoryController();
            if (wang.Is_It_a_Book(itemid))
            {
                using (StreamReader re = new StreamReader(booklocation))
                {
                    string line = re.ReadLine();
                    while(line != null)
                    {
                        string[] col = line.Split('|');
                        if(col[0] == itemid)
                        {
                            int upd = Convert.ToInt32(col[10]) + addnumber;
                            line = col[0] + "|" + col[1] + "|" + col[2] + "|" + col[3] + "|" + col[4] + "|" + col[5] + "|" + 
                                   col[6] + "|" + col[7] + "|" + col[8] + "|" + col[9] + "|" + upd.ToString();
                        }
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(line);
                        }
                        line = re.ReadLine();
                    }
                }
                File.Delete(booklocation);
                File.Move(tempfilelocation, booklocation);
            }
            else
            {
                using (StreamReader re = new StreamReader(softwarelocation))
                {
                    string line = re.ReadLine();
                    while (line != null)
                    {
                        string[] col = line.Split('|');
                        if (col[0] == itemid)
                        {
                            int upd = Convert.ToInt32(col[9]) + addnumber;
                            line = col[0] + "|" + col[1] + "|" + col[2] + "|" + col[3] + "|" + col[4] + "|" + col[5] + "|" +
                                   col[6] + "|" + col[7] + "|" + col[8] + "|" + upd.ToString();
                        }
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(line);
                        }
                        line = re.ReadLine();
                    }
                }
                File.Delete(softwarelocation);
                File.Move(tempfilelocation, softwarelocation);
            }

        }
        static public void Update_Client_Credit(string clientid, double addcredit)
        {
            SalesManager peter = new SalesManager();
            using (StreamReader re = new StreamReader(clientdatalocation))
            {
                string line = re.ReadLine();
                while (line != null)
                {
                    string[] col = line.Split('|');
                    if (col[0] == clientid)
                    {
                        double upd = Convert.ToDouble(col[10]) + addcredit;
                        line = col[0] + "|" + col[1] + "|" + col[2] + "|" + col[3] + "|" + col[4] + "|" + col[5] + "|" +
                               col[6] + "|" + col[7] + "|" + col[8] + "|" + col[9] + "|" + upd.ToString() + "|" + col[11] + "|" + col[12];
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(line);
                    }
                    line = re.ReadLine();
                }
            }
            File.Delete(clientdatalocation);
            File.Move(tempfilelocation, clientdatalocation);
        }
        static public List<string> Order_ID_List()
        {
            List<string> list = new List<string>();
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while(lines != null)
                {
                    string[] col = lines.Split('|');
                    list.Add(col[0]);
                    lines = re.ReadLine();
                }
            }
            return list;
        }
        static public List<Order_Client> Search_Orders_by_ClientID(string clientid)
        {
            List<Order_Client> one = new List<Order_Client>();
            Order_Client a;
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if(col[1].Contains(clientid))
                    {
                        a = new Order_Client();
                        a.OrderID = col[0];
                        a.ClientID = col[1];
                        a.ItemList = col[2];
                        a.OrderMethod = col[3];
                        a.Payment_status = col[4];
                        a.ShippingDate = col[5];
                        a.ExpectedDate = col[6];
                        a.OrderClerkID = col[7];
                        one.Add(a);
                    }
                    lines = re.ReadLine();
                }
            }
            return one;
        } 
        static public List<Order_Client> Searched_Orders_by_Included_Item(string itemid)
        {
            List<Order_Client> one = new List<Order_Client>();
            Order_Client a;
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[2].Contains(itemid))
                    {
                        a = new Order_Client();
                        a.OrderID = col[0];
                        a.ClientID = col[1];
                        a.ItemList = col[2];
                        a.OrderMethod = col[3];
                        a.Payment_status = col[4];
                        a.ShippingDate = col[5];
                        a.ExpectedDate = col[6];
                        a.OrderClerkID = col[7];
                        one.Add(a);
                    }
                    lines = re.ReadLine();
                }
            }
            return one;
        }
        static public List<Order_Client> Searched_Orders_by_Order_Method(string method)
        {
            List<Order_Client> one = new List<Order_Client>();
            Order_Client a;
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[3] == method)
                    {
                        a = new Order_Client();
                        a.OrderID = col[0];
                        a.ClientID = col[1];
                        a.ItemList = col[2];
                        a.OrderMethod = col[3];
                        a.Payment_status = col[4];
                        a.ShippingDate = col[5];
                        a.ExpectedDate = col[6];
                        a.OrderClerkID = col[7];
                        one.Add(a);
                    }
                    lines = re.ReadLine();
                }
            }
            return one;
        }
        static public List<Order_Client> Searched_Orders_by_Payment_Status(string payment_status)
        {
            List<Order_Client> one = new List<Order_Client>();
            Order_Client a;
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[4] == payment_status)
                    {
                        a = new Order_Client();
                        a.OrderID = col[0];
                        a.ClientID = col[1];
                        a.ItemList = col[2];
                        a.OrderMethod = col[3];
                        a.Payment_status = col[4];
                        a.ShippingDate = col[5];
                        a.ExpectedDate = col[6];
                        a.OrderClerkID = col[7];
                        one.Add(a);
                    }
                    lines = re.ReadLine();
                }
            }
            return one;
        }
        static public List<Order_Client> Searched_Orders_by_Shipping_Date(string ship_date)
        {
            List<Order_Client> one = new List<Order_Client>();
            Order_Client a;
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[5] == ship_date)
                    {
                        a = new Order_Client();
                        a.OrderID = col[0];
                        a.ClientID = col[1];
                        a.ItemList = col[2];
                        a.OrderMethod = col[3];
                        a.Payment_status = col[4];
                        a.ShippingDate = col[5];
                        a.ExpectedDate = col[6];
                        a.OrderClerkID = col[7];
                        one.Add(a);
                    }
                    lines = re.ReadLine();
                }
            }
            return one;
        }
        static public List<Order_Client> Searched_Orders_by_Expected_Date(string expect_date)
        {
            List<Order_Client> one = new List<Order_Client>();
            Order_Client a;
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[6] == expect_date)
                    {
                        a = new Order_Client();
                        a.OrderID = col[0];
                        a.ClientID = col[1];
                        a.ItemList = col[2];
                        a.OrderMethod = col[3];
                        a.Payment_status = col[4];
                        a.ShippingDate = col[5];
                        a.ExpectedDate = col[6];
                        a.OrderClerkID = col[7];
                        one.Add(a);
                    }
                    lines = re.ReadLine();
                }
            }
            return one;
        }
        static public List<Order_Client> Searched_Orders_by_Order_Clerk_ID(string orderclerkid)
        {
            List<Order_Client> one = new List<Order_Client>();
            Order_Client a;
            using (StreamReader re = new StreamReader(orderlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[7] == orderclerkid)
                    {
                        a = new Order_Client();
                        a.OrderID = col[0];
                        a.ClientID = col[1];
                        a.ItemList = col[2];
                        a.OrderMethod = col[3];
                        a.Payment_status = col[4];
                        a.ShippingDate = col[5];
                        a.ExpectedDate = col[6];
                        a.OrderClerkID = col[7];
                        one.Add(a);
                    }
                    lines = re.ReadLine();
                }
            }
            return one;
        }
        static public bool Delete_Order(string itemid)
        {
            bool delete = false;
            try
            {
                using (StreamReader re = new StreamReader(orderlocation))
                {
                    string lines = re.ReadLine();
                    while (lines != null)
                    {
                        string[] col = lines.Split('|');
                        if (col[0] == itemid)
                        {
                            using (StreamWriter wr = new StreamWriter(deletedorderlocation, true))
                            {
                                wr.WriteLine(lines);
                            }
                            delete = true;
                        }
                        else
                        {
                            using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                            {
                                wr.WriteLine(lines);
                            }
                        }
                        lines = re.ReadLine();
                    }
                }
                File.Delete(orderlocation);
                File.Move(tempfilelocation, orderlocation);
                File.SetAttributes(deletedorderlocation, FileAttributes.Hidden);
                Process.Start(deletedorderlocation);
            }
            catch
            {
                delete = false;
            }
            return delete;
        }
    }
}
