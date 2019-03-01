using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistributionClassLibrary.Business
{
    public class Orders : Inventory
    {
        public int OrderNumber { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string OrderDate { get; set; }
        public string ShippingDate { get; set; }
        public int OrderQuantity { get; set; }
        public double FinalAmount { get; set; }

        public Orders()
        {
            OrderNumber = 0;
            ClientID = 0;
            ClientName = "";
            OrderDate = "Tuesday, November 21, 2017";
            ShippingDate = "Tuesday, November 21, 2017";
            OrderQuantity = 0;
            FinalAmount = 0.0;
        }         
        public Orders(int oNumber, int cId, string cName, string oDate, string sDate, int oQty, double fAmount)
        {
            OrderNumber = oNumber;
            ClientID = cId;
            ClientName = cName;
            OrderDate = oDate;
            ShippingDate = sDate;
            OrderQuantity = oQty;
            FinalAmount = fAmount;
        }
    }
}    