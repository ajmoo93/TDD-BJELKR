using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
   public class Rentals
    {
        public string Title { get; set; }
        public int SecurityNumber { get; set; }
        public DateTime due { get; set; }

        public Rentals(string title, int ssn, DateTime duetime)
        {
            Title = title;
            SecurityNumber = ssn;
            due = duetime;
        }
    }
}
