using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL.Business.Order
{
    public class Order_Client
    {
        string orderID;
        string clientID;
        string orderMethod;
        string payment_status;
        string expectedDate;
        string shippingDate;
        string orderClerkID;
        string itemList;
        string subtotal;
        string tPS;
        string tVQ;
        string total;

        public string OrderID
        {
            get
            {
                return orderID;
            }

            set
            {
                orderID = value;
            }
        }

        public string ClientID
        {
            get
            {
                return clientID;
            }

            set
            {
                clientID = value;
            }
        }

        public string OrderMethod
        {
            get
            {
                return orderMethod;
            }

            set
            {
                orderMethod = value;
            }
        }

        public string Payment_status
        {
            get
            {
                return payment_status;
            }

            set
            {
                payment_status = value;
            }
        }

        public string ExpectedDate
        {
            get
            {
                return expectedDate;
            }

            set
            {
                expectedDate = value;
            }
        }

        public string ShippingDate
        {
            get
            {
                return shippingDate;
            }

            set
            {
                shippingDate = value;
            }
        }

        public string OrderClerkID
        {
            get
            {
                return orderClerkID;
            }

            set
            {
                orderClerkID = value;
            }
        }

        public string ItemList
        {
            get
            {
                return itemList;
            }

            set
            {
                itemList = value;
            }
        }

        public string Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }

        public string TPS
        {
            get
            {
                return tPS;
            }

            set
            {
                tPS = value;
            }
        }

        public string TVQ
        {
            get
            {
                return tVQ;
            }

            set
            {
                tVQ = value;
            }
        }

        public string Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public Order_Client()
        {
            this.OrderID = "";
            this.ClientID = "";
            this.OrderMethod = "";
            this.Payment_status = "";
            this.ExpectedDate = "";
            this.ShippingDate = "";
            this.OrderClerkID = "";
            this.ItemList = "";
            this.Subtotal = "";
            this.TPS = "";
            this.TVQ = "";
            this.Total = "";
        }
        public Order_Client(string orderID, string clientID, string orderMethod, string payment_status, string expectedDate, string shippingDate, string orderClerkID, string itemList, string subtotal, string tPS, string tVQ, string total)
        {
            this.OrderID = orderID;
            this.ClientID = clientID;
            this.OrderMethod = orderMethod;
            this.Payment_status = payment_status;
            this.ExpectedDate = expectedDate;
            this.ShippingDate = shippingDate;
            this.OrderClerkID = orderClerkID;
            this.ItemList = itemList;
            this.Subtotal = subtotal;
            this.TPS = tPS;
            this.TVQ = tVQ;
            this.Total = total;
        }
    }
}
