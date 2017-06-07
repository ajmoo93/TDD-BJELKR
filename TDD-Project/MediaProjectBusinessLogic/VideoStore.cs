using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (!ValidSsn(socialSecurityNumber))
            {
                throw new WrongFormatException();
            }
                if (Listcustomers.Any(x => x.SSN == socialSecurityNumber))
                {
                    throw new CantAddSameSsnTwiceException();
                }
            Listcustomers.Add(newCustomer);

        }

        public void RentMovie(string movieTitle, string socialSecurityNumber)
        {
            var customer = Listcustomers.FirstOrDefault(x => x.SSN == socialSecurityNumber);
            var movie = ListMovies.FirstOrDefault(x => x.Title == movieTitle);
            if (customer == null)
            {
                throw new NoCustomerInOurSystem();

            }
            //Om filmen inte existerar
            else if (movie == null)
            {
                //throw exception
                throw new CantRentNonExistingMovie();

            }
            //if (!ListMovies.Any(x => x.Title == movieTitle))
            //{

            //}
            rentals.AddRental(movieTitle, socialSecurityNumber);

        }

        public void ReturnMovie(int id, string movieTitle, string socialSecurityNumber)
        {
            rentals.RemoveRental(movieTitle, socialSecurityNumber);
        }

        public List<Movies> GetMovies()
        {
            return ListMovies;
        }

        public bool ValidSsn(string socialsecuritynumber)
        {
            var ssnRegex = @"^\d{4}-\d{2}-\d{2}$";
            if (Regex.IsMatch(socialsecuritynumber, ssnRegex))
            {
                return true;
            }
            return false;
        }
    }
}
