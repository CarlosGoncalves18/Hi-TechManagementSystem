using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistributionClassLibrary.Business
{
    public class Inventory : Publisher
    {
        public int ISBNProduct { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }       
        public int ProductYearPublished { get; set; }
        public int ProductQuantity { get; set; }

        public Inventory()
        {
            ISBNProduct = 1234;
            ProductTitle = "";
            ProductDescription = "";
            ProductPrice = 0.0;
            ProductYearPublished = 2000;
            ProductQuantity = 0;
        }
        public Inventory(int isbnP, string pTitle, string pdescription, double pPrice, int pYearPublished, int pQuantity)
        {
            ISBNProduct = isbnP;
            ProductTitle = pTitle;
            ProductDescription = pdescription;
            ProductPrice = pPrice;
            ProductYearPublished = pYearPublished;
            ProductQuantity = pQuantity;
        }
    }
}