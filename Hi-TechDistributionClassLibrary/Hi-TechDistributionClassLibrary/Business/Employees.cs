using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistributionClassLibrary.Business
{
    public class Employees : Person
    {
        public int EmployeeId { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Status { get; set; }

        public Employees()
        {
            EmployeeId = 0;
            HomePhone = "";
            Email = "";
            JobTitle = "";
            Status = "";
        }
        public Employees(int eID, string fName, string lName, string hphone, string eemail, string jtitle, string sstatus) : base(fName, lName)
        {
            EmployeeId = eID;
            HomePhone = hphone;
            Email = eemail;
            JobTitle = jtitle;
            Status = sstatus;
        }
    }
}