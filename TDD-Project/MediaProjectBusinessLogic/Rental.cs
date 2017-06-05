using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
   public class Rental
    {
        public string Title { get; set; }
        public string SecurityNumber { get; set; }
        public DateTime due { get; set; }

        public Rental(string title, string ssn, DateTime duetime)
        {
            Title = title;
            SecurityNumber = ssn;
            due = duetime;
        }
    }
}
