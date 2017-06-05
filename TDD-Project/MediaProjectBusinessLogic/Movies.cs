using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
    public class Movies 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime dueDate { get; set; }
        

        public Movies(string title, string genre, DateTime duedate)
        {
            Title = title;
            Genre = genre;
            dueDate = duedate;
        }
        
        public Movies()
        {
        }
    }
}
