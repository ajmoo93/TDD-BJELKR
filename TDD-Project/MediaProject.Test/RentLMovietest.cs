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
   public class RentLMovietest
    {
        private IRentals rentals;
        private IDateTime datetime;
        private RentedMovies sut;
        private Rental rental;

        [SetUp]
        public void Setup()
        {
            rentals = Substitute.For<IRentals>();
            datetime = Substitute.For<IDateTime>();
            sut = new RentedMovies(datetime);
            


        }
        [Test]
        public void CanAddRental()
        {
            sut.AddRental("kalle", "5454545");
            var result = sut.GetRentalsFor("5454545");
            Assert.AreEqual("kalle", result[0].Title);
        }
        [Test]
        public void WillGetAThreeDaysLaterDueDate()
        {
            datetime.Now().Returns(new DateTime(2017, 2, 12));
            sut.AddRental("kalle", "5454545");
            var result = sut.GetRentalsFor("5454545");

            Assert.AreEqual(new DateTime(2017, 2, 15), result[0].due);

        }
        [Test]
        public void CantRentMoviesCusOfDueDate()
        {
            var dateTime = new DateTime(2017, 2, 12);
            datetime.Now().Returns(dateTime);
            sut.AddRental("Kalle ", " 5458457");

            datetime.Now().Returns(dateTime.AddDays(4));


            Assert.Throws<MovieWithDueDateFoundException>(() => sut.AddRental("Kalle ", " 5458457"));
        }

        [Test]
        public void CantRentTwoOfTheSamecoppys()
        {
            sut.AddRental("luffsen och rödluvan", "1946-12-12");

            Assert.Throws<CantRentSameMovieTwice>(() => {
                sut.AddRental("luffsen och rödluvan", "1946-12-12");
            });

        }
        [Test]
        public void CantRentMovieThatDoesNotExist()
        {
            
            Assert.Throws<CantRentNonExistingMovie>(() => sut.AddRental("soppa", "1955-05-04"));
        }
    }
}
