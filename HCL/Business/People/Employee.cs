using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Validation;

namespace HCL.Business.People
{
    public class Employee : Person
    {
        private int eID;
        private string position;
        private string phoneNumber;
        private string address;
        private string salary;
        private string status;


    public int EID
        {
            get
            {
                return eID;
            }

            set
            {
                eID = value;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public Employee () : base()
        {
            this.eID = 0;
            this.phoneNumber = "";
            this.address = "";
            this.salary = "";
            this.position = "";
            this.status = "";
        }

        public Employee(int eid, string fname, string lname, string phone, string add, string sal, string pos, string sta) : base(fname,lname)
        {
            this.eID = eid;
            base.FirstName = fname;
            base.LastName = lname;
            this.phoneNumber = phone;
            this.address = add;
            this.salary = sal;
            this.position = pos;
            this.status = sta;
        }

    }
}
