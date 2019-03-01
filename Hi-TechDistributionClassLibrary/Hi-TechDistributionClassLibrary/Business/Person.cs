using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistributionClassLibrary.Business
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()

        {
            FirstName = "";
            LastName = "";
        }
        public Person(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }
    }
}