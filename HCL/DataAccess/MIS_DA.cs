using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Business.People;
using System.IO;
using HCL.Validation;

namespace HCL.DataAccess
{
    static public class MIS_DA
    {
        static private string activedir = @"C:\";
        static private string folderlocation = Path.Combine(activedir, @"JooyeonMok_HCL_FinalProject\");
        static private string userdatalocaion = Path.Combine(folderlocation, "User.dat");
        static private string empdatalocation = Path.Combine(folderlocation, "Employee.dat");
        static private string tempfilelocation = Path.Combine(folderlocation, "Temp_Data.dat");

        static public void Save_Employee(Employee newone)
        {
            using (StreamWriter write = new StreamWriter(empdatalocation, true))
            {
                write.WriteLine(newone.EID.ToString() + "|" + newone.FirstName + "|" +
                                newone.LastName + "|" + newone.PhoneNumber + "|" +
                                newone.Address + "|" + newone.Salary + "|" +
                                newone.Position + "|" + newone.Status);
            }
        }
        static public void Save_User(User newone)
        {
            using (StreamWriter write = new StreamWriter(userdatalocaion, true))
            {
                write.WriteLine(newone.UID.ToString() + "|" + newone.Password + "|" + newone.Usercode.ToString());
            }
        }

        static public void Update_Employee(Employee upd)
        {
            using (StreamReader read = new StreamReader(empdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (upd.EID == Convert.ToInt32(col[0]))
                    {
                        lines = upd.EID.ToString() + "|" + upd.FirstName + "|" +
                                upd.LastName + "|" + upd.PhoneNumber + "|" +
                                upd.Address + "|" + upd.Salary + "|" +
                                upd.Position + "|" + upd.Status;
                    }
                    using (StreamWriter write = new StreamWriter(tempfilelocation, true))
                    {
                        write.WriteLine(lines);
                    }
                    lines = read.ReadLine();
                }
            }
            File.Delete(empdatalocation);
            File.Move(tempfilelocation, empdatalocation);
            File.Delete(tempfilelocation);
        }
        static public Employee Searched_Employee_by_ID(int id)
        {
            Employee newone = new Employee();
            using (StreamReader read = new StreamReader(empdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (id == Convert.ToInt32(col[0]))
                    {
                        newone.EID = Convert.ToInt32(col[0]);
                        newone.FirstName = col[1];
                        newone.LastName = col[2];
                        newone.PhoneNumber = col[3];
                        newone.Address = col[4];
                        newone.Salary = col[5];
                        newone.Position = col[6];
                        newone.Status = col[7];
                        break;
                    }
                    lines = read.ReadLine();
                }
            }
            return newone;
        }

        static public List<Employee> Searched_Employees_by_Fname(string name)
        {
            List<Employee> fname = new List<Employee>();
            Employee newone;
            using (StreamReader read = new StreamReader(empdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    name = name.ToLower();
                    if (name == col[1].ToLower() || col[1].ToLower().Contains(name))
                    {
                        newone = new Employee();
                        newone.EID = Convert.ToInt32(col[0]);
                        newone.FirstName = col[1];
                        newone.LastName = col[2];
                        newone.PhoneNumber = col[3];
                        newone.Address = col[4];
                        newone.Salary = col[5];
                        newone.Position = col[6];
                        newone.Status = col[7];
                        fname.Add(newone);
                    }
                    lines = read.ReadLine();
                }
            }
            return fname;
        }
        static public List<Employee> Searched_Employees_by_Lname(string name)
        {
            List<Employee> lname = new List<Employee>();
            Employee newone;
            using (StreamReader read = new StreamReader(empdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    name = name.ToLower();
                    if (name == col[2].ToLower() || col[2].ToLower().Contains(name))
                    {
                        newone = new Employee();
                        newone.EID = Convert.ToInt32(col[0]);
                        newone.FirstName = col[1];
                        newone.LastName = col[2];
                        newone.PhoneNumber = col[3];
                        newone.Address = col[4];
                        newone.Salary = col[5];
                        newone.Position = col[6];
                        newone.Status = col[7];
                        lname.Add(newone);
                    }
                    lines = read.ReadLine();
                }
            }
            return lname;
        }
        static public List<Employee> Searched_Employees_by_Position(string pos)
        {
            List<Employee> position = new List<Employee>();
            Employee newone;
            using (StreamReader read = new StreamReader(empdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    pos = pos.ToLower();
                    if (pos == col[6].ToLower() || col[6].ToLower().Contains(pos))
                    {
                        newone = new Employee();
                        newone.EID = Convert.ToInt32(col[0]);
                        newone.FirstName = col[1];
                        newone.LastName = col[2];
                        newone.PhoneNumber = col[3];
                        newone.Address = col[4];
                        newone.Salary = col[5];
                        newone.Position = col[6];
                        newone.Status = col[7];
                        position.Add(newone);
                    }
                    lines = read.ReadLine();
                }
            }
            return position;
        }
        static public List<Employee> Searched_Employees_by_Status(string sta)
        {
            List<Employee> status = new List<Employee>();
            Employee newone;
            using (StreamReader read = new StreamReader(empdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    sta = sta.ToLower();
                    if (sta == col[7].ToLower() || col[7].ToLower().Contains(sta))
                    {
                        newone = new Employee();
                        newone.EID = Convert.ToInt32(col[0]);
                        newone.FirstName = col[1];
                        newone.LastName = col[2];
                        newone.PhoneNumber = col[3];
                        newone.Address = col[4];
                        newone.Salary = col[5];
                        newone.Position = col[6];
                        newone.Status = col[7];
                        status.Add(newone);
                    }
                    lines = read.ReadLine();
                }
            }
            return status;
        }
        static public List<User> Searched_User_by_Role(int code)
        {
            List<User> usercode = new List<User>();
            User newone;
            using (StreamReader read = new StreamReader(userdatalocaion))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (code == Convert.ToInt32(col[2]))
                    {
                        newone = new User();
                        newone.UID = Convert.ToInt32(col[0]);
                        newone.Password = col[1];
                        newone.Usercode = Convert.ToInt32(col[2]);

                        usercode.Add(newone);
                    }
                    lines = read.ReadLine();
                }
            }
            return usercode;
        }
        static public User Searched_User_by_ID(string id)
        {
            User newone = new User();
            using (StreamReader read = new StreamReader(userdatalocaion))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (id == (col[0]))
                    {
                        newone.UID = Convert.ToInt32(col[0]);
                        newone.Password = col[1];
                        newone.Usercode = Convert.ToInt32(col[2]);
                        break;
                    }
                    lines = read.ReadLine();
                }
            }
            return newone;
        }
        static public List<Employee> List_Employee()
        {
            List<Employee> list = new List<Employee>();
            Employee toadd;

            using (StreamReader read = new StreamReader(empdatalocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    toadd = new Employee();
                    toadd.EID = Convert.ToInt32(col[0]);
                    toadd.FirstName = col[1];
                    toadd.LastName = col[2];
                    toadd.PhoneNumber = col[3];
                    toadd.Address = col[4];
                    toadd.Salary = col[5];
                    toadd.Position = col[6];
                    toadd.Status = col[7];
                    list.Add(toadd);
                    lines = read.ReadLine();
                }
            }
            return list;
        }
        static public List<User> List_User()
        {
            List<User> list = new List<User>();
            User toadd;
            using (StreamReader read = new StreamReader(userdatalocaion))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    toadd = new User();
                    toadd.UID = Convert.ToInt32(col[0]);
                    toadd.Password = "-";
                    toadd.Usercode = Convert.ToInt32(col[2]);
                    list.Add(toadd);
                    lines = read.ReadLine();
                }
            }
            return list;
        }
        static public void Update_User(User a)
        {
            using (StreamReader read = new StreamReader(userdatalocaion))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (a.UID == Convert.ToInt32(col[0]))
                    {
                        lines = a.UID + "|" + a.Password + "|" + a.Usercode;
                    }
                    using (StreamWriter write = new StreamWriter(tempfilelocation, true))
                    {
                        write.WriteLine(lines);
                    }
                    lines = read.ReadLine();
                }
            }
            File.Delete(userdatalocaion);
            File.Move(tempfilelocation, userdatalocaion);
        }
    }
}
