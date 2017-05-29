using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
    public class VideoStore : IVideoStore
    {
        List<Movies> ListMovies = new List<Movies>();
        List<Customer> Listcustomers = new List<Customer>();
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
            var movie = ListMovies.First(x => x.Title == movieTitle);
            Customer rentMovies = new Customer()
            {
                SSN = socialSecurityNumber,
                Movies = movie
            };

            Listcustomers.Add(rentMovies);
        }

        public void ReturnMovie(int id, string movieTitle, string socialSecurityNumber)
        {
            var Return = ListMovies.Find(x => x.Id.Equals(id));
            ListMovies.Remove(Return);
           
        }
    }
}
