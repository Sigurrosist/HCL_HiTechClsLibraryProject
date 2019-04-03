using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace HCL.Validation
{
    static public class Validators
    {
        static public string Valid_ID(string id)
        {
            id = id.Trim();
            Regex Isdigit = new Regex(@"^/d{4}$");
            if (!Isdigit.IsMatch(id))
            {
                id = "";
            }
            return id;
        }
        static public string Valid_Name(string name) // returns "" when it is not correct
            {
                name = name.Trim();
                string valid_name = "";
                Regex name_regex = new Regex(@"^[a-zA-Z ]+$");

                if (name_regex.IsMatch(name))
                {
                    string to_add_names = "";
                    string[] names = name.Split(' ');
                    foreach (string i in names)
                    {
                        to_add_names = i.ToLower();
                        valid_name += char.ToUpper(to_add_names[0]) + to_add_names.Substring(1) + " ";
                    }
                    valid_name = valid_name.Trim();
                }
                return valid_name;
            }
        static public string Valid_digit(string num)// allows integers and doubles - returns "" when it is not valid
            {
                string number = num.Trim();
                Regex Isdigit = new Regex(@"^\d+(\.\d+)?$");
                if (!Isdigit.IsMatch(number))
                {
                    number = "";
                }
                return number;
            }
        static public string Valid_PhoneNumber(string phonenumber)// returns "" when it is not valid
        {
            string toreturn = Regex.Replace(phonenumber, @"\D", "");
            Regex valid_phone = new Regex(@"^\d{10}$");
            if (!valid_phone.IsMatch(toreturn))
            {
                toreturn = "";
            }
            else
            {
                string part1 = toreturn.Substring(0, 3);
                string part2 = toreturn.Substring(3, 3);
                string part3 = toreturn.Substring(6, 4);
                toreturn = part1 + "-" + part2 + "-" + part3;
            }
                return toreturn;
        }
        static public string Valid_PostalCode (string postcode) // returns "" when it is not valid
        {
            postcode = postcode.Replace(" ", "");
            Regex valid_poscode = new Regex(@"[A-Za-z]{1}\d{1}[A-Za-z]{1}\d{1}[A-Za-z]{1}\d{1}");

            if (valid_poscode.IsMatch(postcode))
            {
                postcode = postcode.ToUpper();
                postcode = postcode.Replace(" ", "");
                postcode = postcode[0] + postcode[1] + postcode[2] + " " + postcode[3] + postcode[4] + postcode[5];
            }
            else
            {
                postcode = "";
            }
            return postcode;
        }
        static public string Valid_Email_Address(string emailaddress) // returns "" when it is not valid
        {
            string toreturn = "";
            try
            {
                MailAddress mail = new MailAddress(emailaddress);
                toreturn = emailaddress;
            }
            catch (FormatException)
            {
                toreturn = "";
            }

            return toreturn;
        }
        static public string Valid_13_Digits(string tocheck) //returns "" when it is not valid
        {
            string toreturn = Regex.Replace(tocheck, @"\D", "");
            Regex valid_ok = new Regex(@"^\d{13}$");
            if(!valid_ok.IsMatch(toreturn))
            {
                toreturn = "";
            }
            return toreturn;
        }
        static public string Valid_10_Digits(string tocheck) //returns "" when it is not valid
        {
            string toreturn = Regex.Replace(tocheck, @"\D", "");
            Regex valid_ok = new Regex(@"^\d{10}$");
            if (!valid_ok.IsMatch(toreturn))
            {
                toreturn = "";
            }
            return toreturn;
        }
    }
}
