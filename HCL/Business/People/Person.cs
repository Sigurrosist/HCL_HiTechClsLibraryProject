using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Validation;

namespace HCL.Business.People
{
    public class Person
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }
        public Person()
        {
            this.firstName = "";
            this.lastName = "";
        }
        public Person(string fname, string lname)
        {
            this.firstName = fname;
            this.lastName = lname;
        }
    }
}
