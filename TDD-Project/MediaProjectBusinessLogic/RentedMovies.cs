using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
    public class RentedMovies : IRentals
    {
        private List<Rental> rentals;
        private IDateTime datetime;
        

        public RentedMovies(IDateTime date)
        {
            //datestub blir som DateTime för vi gör en IDateTime och stubbar den
            this.datetime = date;
            rentals = new List<Rental>();
        }
        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
             
            var moviesRentedByCustomers = rentals.FirstOrDefault(x => x.SecurityNumber == socialSecurityNumber && x.Title == movieTitle);
            var hasLateReturns = rentals.Any(x => x.SecurityNumber == socialSecurityNumber && x.due < datetime.Now());

            if (hasLateReturns)
            {
                throw new MovieWithDueDateFoundException();
            }

            if (moviesRentedByCustomers == null)
            {
                rentals.Add(new Rental(movieTitle, socialSecurityNumber, datetime.Now().AddDays(3)));
            }
            else
            {
                throw new CantRentSameMovieTwice();
            }
           






        }

        public List<Rental> GetRentalsFor(string socialSecurityNumber)
        {
            //Denna metod är för att hämta alla filmerna som är uthyrda till en kund
            //var rentedmoviesfromcustomer = listcustomers.find(x => x.ssn == socialsecuritynumber);
            var result = rentals.Where(x => x.SecurityNumber == socialSecurityNumber).ToList();
            
            return result;
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }
    }
}
