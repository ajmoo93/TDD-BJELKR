using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
    public class RentedMovies : IRentals
    {

        //den här listan innehåller uthyrda filmer
        List<Customer> ListCustomers = new List<Customer>();

        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            // hitta den rätta kunden i listan
            var result = ListCustomers.First(x => x.SSN == socialSecurityNumber);


            Movies movie = new Movies()
            {
                Title = movieTitle
            };

            // Här läggs en uthyrd film in i listan 
            Customer rentedMovies = new Customer()
            {
                FirstName = result.FirstName,
                SSN = socialSecurityNumber,
                movies = movie
            };


            ListCustomers.Add(rentedMovies);
        }

        public List<RentedMovies> GetRentalsFor(string socialSecurityNumber)
        {
            //Denna metod är för att hämta alla filmerna som är uthyrda till en kund
            //var rentedmoviesfromcustomer = listcustomers.find(x => x.ssn == socialsecuritynumber);
            return null;
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }
    }
}
