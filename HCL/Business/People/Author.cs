using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Validation;

namespace HCL.Business.People
{
    public class Author : Person
    {
        private string authorID;
        private string email;

        public string AuthorID
        {
            get
            {
                return authorID;
            }

            set
            {
                authorID = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public Author() : base()
        {
            this.authorID = "";
        }

        public Author(string aid, string fname, string lname, string email) : base (fname, lname)
        {
            this.authorID = aid;
            base.FirstName = fname;
            base.LastName = lname;
        }
    }
}
