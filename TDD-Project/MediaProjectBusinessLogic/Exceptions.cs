using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
   public class CantAddAFourthMovie : Exception
    {
        public CantAddAFourthMovie()
        {

        }
        
        }
    public class CantRentSameMovieTwice : Exception
    {
        public CantRentSameMovieTwice()
        {

        }
    }
}
