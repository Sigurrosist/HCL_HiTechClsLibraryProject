using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HCL.Business.People;

namespace HCL.DataAccess
{
    class UserDA
    {
        static private string activedir = @"C:\";
        static private string folderlocation = Path.Combine(activedir, @"JooyeonMok_HCL_FinalProject\");
        static private string userdatalocaion = Path.Combine(folderlocation, "User.dat");
        static private string tempfilelocation = Path.Combine(folderlocation, "Temp_Data.dat");
        static private string empdatalocation = Path.Combine(folderlocation, "Employee.dat");


        static public void Modify_Password(int uid, int new_pwd)
        {
            using (StreamReader read = new StreamReader(userdatalocaion))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    using (StreamWriter modify = new StreamWriter(tempfilelocation, true))
                    {
                        string[] col = lines.Split('|');
                        if (uid == Convert.ToInt32(col[0]))
                        {
                            lines = col[0] + "|" + new_pwd.ToString() + "|" + col[2];
                        }
                        modify.WriteLine(lines);
                    }
                    lines = read.ReadLine();
                }
            }
            File.Delete(userdatalocaion);
            File.Move(tempfilelocation, userdatalocaion);
        }
        static public bool Valid_Login(string id, string pass)
        {
            bool ok = false;

            using (StreamReader read = new StreamReader(userdatalocaion))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if ((id.Trim() == col[0]) && (pass.Trim() == col[1]))
                    {
                        ok = true;
                        break;
                    }
                    lines = read.ReadLine();
                }
            }
            return ok;
        }
        static public int ID_Generator()
        {
            int id = 0;
            using (StreamReader read = new StreamReader(empdatalocation))
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
