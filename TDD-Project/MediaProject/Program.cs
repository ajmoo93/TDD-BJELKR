using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaProjectBusinessLogic;

namespace MediaProject
{
   public class Program
    {
        static void Main(string[] args)
        {
            //För att vi kör dependency injection så skall vi ha det såhär
            var Call = new VideoStore( new RentedMovies(new MyDatTime()));
        }
    }
}
