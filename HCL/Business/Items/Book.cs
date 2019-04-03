using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL.Business.Items
{
    public class Book : Item
    {
        private string iSBN10;
        private string iSBN13;
        public string ISBN10
        {
            get
            {
                return iSBN10;
            }

            set
            {
                iSBN10 = value;
            }
        }

        public string ISBN13
        {
            get
            {
                return iSBN13;
            }

            set
            {
                iSBN13 = value;
            }
        }
        public Book() : base()
        {
            this.iSBN10 = "";
            this.iSBN13 = "";
        }
        public Book(string iD, string title, string authorID, string category, string type, string pub_Year, string pubID, double unitPrice, string isbn10, string isbn13, int quan) : base(iD, title, authorID, category, type, pub_Year, pubID, unitPrice, quan)
        {
            base.ID = iD;
            base.Title = title;
            base.AuthorID = authorID;
            base.Category = category;
            base.Type = type;
            base.Pub_Year = pub_Year;
            base.PubID = pubID;
            base.UnitPrice = unitPrice;
            this.ISBN10 = isbn10;
            this.ISBN13 = isbn13;
            base.Quantity = quan;
        }
    }
}
