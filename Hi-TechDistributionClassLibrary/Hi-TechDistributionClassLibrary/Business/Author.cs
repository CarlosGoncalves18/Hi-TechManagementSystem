using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_TechDistributionClassLibrary.Business
{
    public class Author : Person
    {
        public int AuthorID { get; set; }
        public string AuthorEmail { get; set; }
  
        public Author()
        {
            AuthorID = 12345;
            AuthorEmail = "";

        }
        public Author(int aId, string aemail)
        {
            AuthorID = aId;
            AuthorEmail = aemail;
        }
    }
}