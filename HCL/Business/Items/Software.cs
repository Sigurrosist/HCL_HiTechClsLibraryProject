using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Validation;

namespace HCL.Business.Items
{
    public class Software : Item
    {
        private string software_Type;

        public string Software_Type
        {
            get
            {
                return software_Type;
            }

            set
            {
                software_Type = value;
            }
        }

        public Software() : base ()
        {
            this.software_Type = "";
        }
        public Software(string iD, string title, string authorID, string category, string type, string pub_Year, string pubID, double unitPrice, string s_type, int quan) : base(iD, title, authorID, category, type, pub_Year, pubID, unitPrice, quan)
        {
            base.ID = iD;
            base.Title = title;
            base.AuthorID = authorID;
            base.Category = category;
            base.Type = type;
            base.Pub_Year = pub_Year;
            base.PubID = pubID;
            base.UnitPrice = unitPrice;
            this.Software_Type = s_type;
            base.Quantity = quan;
        }
    }
}
