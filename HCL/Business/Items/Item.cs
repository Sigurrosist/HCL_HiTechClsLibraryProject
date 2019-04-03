using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.Validation;

namespace HCL.Business.Items
{
    public class Item
    {
        private string iD;
        private string title;
        private string authorID;
        private string category;
        private string type;
        private string pub_Year;
        private string pubID;
        private double unitPrice;
        private int quantity;



        public string ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

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

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Pub_Year
        {
            get
            {
                return pub_Year;
            }

            set
            {
                pub_Year = value;
            }
        }

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

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public Item()
        {
            this.ID = "";
            this.Title = "";
            this.AuthorID = "";
            this.Category = "";
            this.Type = "";
            this.Pub_Year = "";
            this.PubID = "";
            this.UnitPrice = 0;
            this.quantity = 0;
        }
        public Item(string iD, string title, string authorID, string category, string type, string pub_Year, string pubID, double unitPrice, int quan)
        {
            this.ID = iD;
            this.Title = title;
            this.AuthorID = authorID;
            this.Category = category;
            this.Type = type;
            this.Pub_Year = pub_Year;
            this.PubID = pubID;
            this.UnitPrice = unitPrice;
            this.quantity = quan;
        }
    }
}
