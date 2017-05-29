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
            Movies movie = new Movies()
            {
                Title = movieTitle
            };

            // Här läggs en uthyrd film in i listan 
            Customer rentedMovies = new Customer()
            {
                SSN = socialSecurityNumber,
                Movies = movie
            };


            ListCustomers.Add(rentedMovies);
        }

        public List<RentedMovies> GetRentalsFor(string socialSecurityNumber)
        {
            var rentedMoviesFromCustomer = ListCustomers.Find(x => x.SSN == socialSecurityNumber);
            return ListOfRentedMovies;
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }
    }
}
