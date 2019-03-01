using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistributionClassLibrary.Business
{
    public class Publisher : Author
    {
        public string PublisherName { get; set; }
        public string PublisherEmail { get; set; }
        public string PublisherAddress { get; set; }
        public string PublisherCity { get; set; }
        public string PublisherCountry { get; set; }
        public string PublisherZipCode { get; set; }

        public Publisher()
        {
            PublisherName = "";
            PublisherEmail = "";
            PublisherAddress = "";
            PublisherCity = "";
            PublisherCountry = "";
            PublisherZipCode = "";

        }
        public Publisher(string pName, string pEmail, string pAddress, string pCity, string pCountry, string pZipCode)
        {
            PublisherName = pName;
            PublisherEmail = pEmail;
            PublisherAddress = pAddress;
            PublisherName = pCity;
            PublisherEmail = pCountry;
            PublisherAddress = pZipCode;
        }
    }
}
