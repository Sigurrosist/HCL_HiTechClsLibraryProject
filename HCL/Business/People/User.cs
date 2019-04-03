using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Validation;
using HCL.DataAccess;

namespace HCL.Business.People
{
    public class User
    {
        private int uID;
        private string password;
        private int usercode;

        public int UID
        {
            get
            {
                return uID;
            }

            set
            {
                uID = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int Usercode
        {
            get
            {
                return usercode;
            }

            set
            {
                usercode = value;
            }
        }

        public User()
        {
            this.uID = 0;
            this.password = "";
            this.usercode = 0;
        }

        public User(int uid, string pass, int code)
        {
            this.uID = uid;
            this.password = pass;
            this.usercode = 0;
        }
        public void Modify_Password(int uid, int new_pwd)
        {
            UserDA.Modify_Password(uid, new_pwd);
        }
        public bool Valid_login(string id, string pass)
        {
            return UserDA.Valid_Login(id, pass);
        }
        public int ID_Generator()
        {
            return UserDA.ID_Generator();
        }

    }
}
