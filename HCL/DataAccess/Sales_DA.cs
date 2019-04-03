using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Business.Company;
using HCL.Business.People;
using System.IO;

namespace HCL.DataAccess
{
    static public class Sales_DA
    {
        static private string activedir = @"C:\";
        static private string folderlocation = Path.Combine(activedir, @"JooyeonMok_HCL_FinalProject\");
        static private string clientdatalocation = Path.Combine(folderlocation, "Client.dat");
        static private string tempfilelocation = Path.Combine(folderlocation, "Temp_Data.dat");

        static public void Save_New_Client(Institute newone)
        {
            using (StreamWriter wr = new StreamWriter(clientdatalocation, true))
            {
                wr.WriteLine(
                    newone.Id + "|" + newone.Name + "|" + newone.Street_Number + "|" + newone.Street_Name + "|" + 
                    newone.City + "|" + newone.PostalCode + "|" + newone.Phone + "|" + newone.Fax + "|" + 
                    newone.Email + "|" + newone.Person_in_Charge + "|" + newone.Credit_Left + "|" + 
                    newone.Credit_Contract + "|" + newone.Status);
            }
        }
        static public void Update_Client(Institute upd)
        {
            using (StreamReader read = new StreamReader(clientdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (upd.Id == col[0])
                    {
                        lines = upd.Id + "|" + upd.Name + "|" + upd.Street_Number + "|" + upd.Street_Name + "|" + 
                            upd.City + "|" + upd.PostalCode + "|" + upd.Phone + "|" + upd.Fax + "|" + 
                            upd.Email + "|" + upd.Person_in_Charge + "|" + upd.Credit_Left + "|" + upd.Credit_Contract + "|" + upd.Status;
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = read.ReadLine();
                }
            }
            File.Delete(clientdatalocation);
            File.Move(tempfilelocation, clientdatalocation);
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
        static public List<Institute> Search_Client_by_Name(string name)
        {
            List<Institute> list = new List<Institute>();
            Institute newone;
            using (StreamReader read = new StreamReader(clientdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');

                    if (col[1].ToLower().Contains(name.ToLower()))
                    {
                        newone = new Institute();
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
                    }
                    lines = read.ReadLine();
                }
            }
            return list;
        }
        static public List<Institute> Search_Client_by_Credit_Left(double credit_left)
        {
            List<Institute> list = new List<Institute>();
            Institute newone;
            using (StreamReader read = new StreamReader(clientdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');

                    if (Convert.ToDouble(col[10]) <= credit_left)
                    {
                        newone = new Institute();
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
                    }
                    lines = read.ReadLine();
                }
            }
            return list;
        }
        static public Institute Search_Client_by_ID(int id)
        {
            Institute newone = new Institute();
            using (StreamReader read = new StreamReader(clientdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');

                    if (Convert.ToInt32(col[0]) == id)
                    {
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
                        break;
                    }
                    lines = read.ReadLine();
                }
            }
            return newone;
        }
        static public int ID_Generator()
        {
            int id = 0;
            using (StreamReader read = new StreamReader(clientdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    id = Convert.ToInt32(col[0]);
                    lines = read.ReadLine();
                }
                id = id + 1;
            }
            return id;
        }
    }
}



