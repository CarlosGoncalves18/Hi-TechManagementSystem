using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistributionClassLibrary.Business
{
    public class Client : Inventory
    {
        public int ClientID { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionAddress { get; set; }
        public string InstitutionCity { get; set; }
        public string InstitutionZipCode { get; set; }
        public string InstitutionPhoneNumber { get; set; }
        public string InstitutionEmail { get; set; }

        public Client()
        {
            ClientID = 12345;
            InstitutionName = "College LaSalle";
            InstitutionAddress = "200, Rue Sainte-Catherine Ouest";
            InstitutionCity = "Montreal";
            InstitutionZipCode = "H3H1R6";
            InstitutionPhoneNumber = "514-939-4444";
            InstitutionEmail = "lasallecollege@gmail.com";
        }
        public Client(int cID, string cName, string cAddress, string cCity, string cZipCode, string cNumber, string cEmail)
        {
            ClientID = cID;
            InstitutionName = cName;
            InstitutionAddress = cAddress;
            InstitutionCity = cCity;
            InstitutionZipCode = cZipCode;
            InstitutionPhoneNumber = cNumber;
            InstitutionEmail = cEmail;
        }
    }
}
