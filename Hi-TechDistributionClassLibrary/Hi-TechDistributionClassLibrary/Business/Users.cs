using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistributionClassLibrary.Business
{
    public class Users : Employees
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserJobTitle { get; set; }
        
        public Users()
        {
            UserName = "";
            Password = "";
            UserJobTitle = "";
        }
        public Users(string uname, string pass, string ujtitle)
        {
            UserName = uname;
            Password = pass;
            UserJobTitle = ujtitle;
        }
    }
}