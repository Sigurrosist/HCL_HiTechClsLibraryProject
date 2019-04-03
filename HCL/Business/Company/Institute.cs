
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Validation;
using HCL.DataAccess;

namespace HCL.Business.Company
{
    public class Institute
    {
        private string id;
        private string name;
        private string fax;
        private string street_Number;
        private string street_Name;
        private string city;
        private string postalCode;
        private string credit_Left;
        private string credit_Contract;
        private string email;
        private string phone;
        private string person_in_Charge;
        private string status;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }

        public string Street_Number
        {
            get
            {
                return street_Number;
            }

            set
            {
                street_Number = value;
            }
        }

        public string Street_Name
        {
            get
            {
                return street_Name;
            }

            set
            {
                street_Name = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return postalCode;
            }

            set
            {
                postalCode = value;
            }
        }

        public string Credit_Left
        {
            get
            {
                return credit_Left;
            }

            set
            {
                credit_Left = value;
            }
        }

        public string Credit_Contract
        {
            get
            {
                return credit_Contract;
            }

            set
            {
                credit_Contract = value;
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

        public string Person_in_Charge
        {
            get
            {
                return person_in_Charge;
            }

            set
            {
                person_in_Charge = value;
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

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public Institute()
        {
            this.Id = "";
            this.Name = "";
            this.Fax = "";
            this.Street_Number = "";
            this.Street_Name = "";
            this.City = "";
            this.PostalCode = "";
            this.Credit_Left = "";
            this.Credit_Contract = "";
            this.Email = "";
            this.Person_in_Charge = "";
            this.Status = "";
            this.Phone = "";
        }
        public Institute(string id, string name, string fax, string street_Number, string street_Name, string city, string postalCode, string credit_Left, string credit_Contract, string email, string person_in_Charge, string status, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Fax = fax;
            this.Street_Number = street_Number;
            this.Street_Name = street_Name;
            this.City = city;
            this.PostalCode = postalCode;
            this.Credit_Left = credit_Left;
            this.Credit_Contract = credit_Contract;
            this.Email = email;
            this.Person_in_Charge = person_in_Charge;
            this.Status = status;
            this.Phone = phone;
        }

        public int Client_ID_Generator()
        {
            return Sales_DA.ID_Generator();
        }
    }
}
