using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Validation;

namespace HCL.Business.Company
{
    public class Publisher
    { 
        private string pubID;
        private string pub_Name;

        public string PubID
        {
            get
            {
                return pubID;
            }

            set
            {
                pubID = value;
            }
        }

        public string Pub_Name
        {
            get
            {
                return pub_Name;
            }

            set
            {
                pub_Name = value;
            }
        }
        public Publisher()
        {
            this.pubID = "";
            this.pub_Name = "";
        }
        public Publisher (string id, string name)
        {
            this.pubID = id;
            this.pub_Name = name;
        }
        
    }
}

