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
    public class NoTitleOnMovieException : Exception
    {
        public NoTitleOnMovieException()
        {

        }
    }
    public class NoCustomerInOurSystem : Exception
    {
        public NoCustomerInOurSystem()
        {

        }
    }
    public class MovieWithDueDateFoundException : Exception
    {
        public MovieWithDueDateFoundException()
        {

        }
    }  
    public class CantRentaNonExistingMovie : Exception
    {
        public CantRentaNonExistingMovie()
        {

        }
    }
    public class CantAddSameSsnTwiceException : Exception
    {
        public CantAddSameSsnTwiceException()
        {

        }
    }
    
}
