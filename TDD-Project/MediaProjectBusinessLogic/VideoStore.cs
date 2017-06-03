using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
    public class VideoStore : IVideoStore
    {
        private IRentals rentals;
        List<Movies> ListMovies = new List<Movies>();
        List<Customer> Listcustomers = new List<Customer>();


        public VideoStore(IRentals _rentals)
        {
            rentals = _rentals;
        }

        public void AddMovie(Movies movie)
        {
            
            ListMovies.Add(movie);
        }

        public List<Customer> GetCustomers()
        {
            return Listcustomers;
        }

        public void RegisterCustomer(string name, string socialSecurityNumber)
        {
            Customer newCustomer = new Customer()
            {
                FirstName = name,
                SSN = socialSecurityNumber
            };
            Listcustomers.Add(newCustomer);
        }

        public void RentMovie(string movieTitle, string socialSecurityNumber)
        {
            //Lista av custommrs/Movies
            //Du måste räkna antalet filmer av en som en kund har
            //Måste förbjuda att hyra en fjärde.
            if(ListMovies.Contains(movieTitle))
            if (ListMovies.Count(x => x.Title.Equals(movieTitle)) > 3)
                throw new CantAddAFourthMovie();
            else
            {
                rentals.AddRental(movieTitle, socialSecurityNumber);

            }
        }

        public void ReturnMovie(int id, string movieTitle, string socialSecurityNumber)
        {
            var movieReturn = ListMovies.Find(x => x.Id.Equals(id) && x.Equals(socialSecurityNumber) && x.Equals(movieTitle));
            ListMovies.Remove(movieReturn);
           
        }

        public List<Movies> GetMovies()
        {
            return ListMovies;
        }
    }
}
