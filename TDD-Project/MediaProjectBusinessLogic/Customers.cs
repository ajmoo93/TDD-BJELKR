using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string SSN { get; set; }
        public Movies Movies { get; set; }

        public Customer(string firstName, string ssn)
        {
            FirstName = firstName;
            SSN = ssn;
        }

        public Customer()
        {
        }
    }
}
