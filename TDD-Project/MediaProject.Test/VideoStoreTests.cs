using MediaProjectBusinessLogic;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProject.Test
{
    [TestFixture]
    public class VideoStoreTests
    {
        private IRentals rentals;
        private IDateTime dateStub;
        private VideoStore sut;
        private RentedMovies sutRent;
        private Customer customer1;
        private Movies movie1, NotitleOnMovie;

        [SetUp]
        public void Setup()
        {
            rentals = Substitute.For<IRentals>();
            dateStub = Substitute.For<IDateTime>();
            sut = new VideoStore(rentals);
            
            movie1 = new Movies() {Id = 0, Title = "Kalle Anka", Genre = "Animation"};
            NotitleOnMovie = new Movies() { Id = 0, Title = "", Genre = "Comedy" };

            customer1 = new Customer() { FirstName = "KallePer", movies = movie1, SSN = "1994-12-05" };
        }
        [Test]
        public void CanAddMoviesToStore()
        {
            sut.AddMovie(movie1);
            var result = sut.GetMovies().First(x => x.Id == movie1.Id);

            Assert.AreEqual(movie1, result);
        }
        [Test]
        public void CanRegisterCustommer()
        {
            sut.RegisterCustomer(customer1.FirstName, customer1.SSN);
            var result = sut.GetCustomers();

            Assert.AreEqual(customer1.SSN, result[0].SSN);
            Assert.AreEqual(customer1.FirstName, result[0].FirstName);
        }
        [Test]
        public void CanRentMovie()
        {
            sut.AddMovie(movie1);
            sut.RegisterCustomer(customer1.FirstName, customer1.SSN);
            sut.RentMovie(movie1.Title, customer1.SSN);

            rentals.Received().AddRental(Arg.Is(movie1.Title), Arg.Is(customer1.SSN));
        }
        [Test]
        public void CanReturnAMovie()
        {
            //Addera en movie
            //Registrera en kund
            //Låna ut filmen först
            sut.AddMovie(movie1);
            sut.RegisterCustomer(customer1.FirstName, customer1.SSN);
            sut.RentMovie(movie1.Title, customer1.SSN);
            sut.ReturnMovie(movie1.Id, movie1.Title, customer1.SSN);
            rentals.Received().RemoveRental(Arg.Is(movie1.Title), Arg.Is(customer1.SSN));
            
        }
        [Test]
        public void ThrowexceptionWhenAddingFourthMovie()
        {
            sut.AddMovie(movie1);
            sut.AddMovie(movie1);
            sut.AddMovie(movie1);

            Assert.Throws<CantAddAFourthMovie>(() => sut.AddMovie(movie1));

        }
        
        //[Test]
        //public void NoExistingMovititle()
        //{
           
        //    Assert.Throws<NoTitleOnMovieException>(() => sut.AddMovie(NotitleOnMovie));
        //}
      
    }
}
