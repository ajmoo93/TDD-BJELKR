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
        private IDateTime dateStub;
        List<Movies> ListMovies = new List<Movies>();
        List<Customer> Listcustomers = new List<Customer>();


        public VideoStore(IRentals _rentals, IDateTime datestub)
        {
            rentals = _rentals;
            //datestub blir som DateTime för vi gör en IDateTime och stubbar den
            this.dateStub = datestub;
        }

        public void AddMovie(Movies movie)
        {
            if (ListMovies.Count(x => x.Title.Equals(movie.Title)) >= 3)
                throw new CantAddAFourthMovie();
            //Att sätta movie.title == null går inte 
            //så får använda IsNullorEmpty(movie.title)
            if (string.IsNullOrEmpty(movie.Title))
                throw new NoTitleOnMovieException();
            else
            {
                ListMovies.Add(movie);
            }
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
            if (Listcustomers.Contains(new Customer { SSN = socialSecurityNumber}))
                throw new CantRentSameMovieTwice();
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
