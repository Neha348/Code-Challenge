using Coding.Challenge.Firstname.Lastname;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_TestCases.Test_Methods
{

    public class BLTest
    {
        private Mock<Repository> CarRepository;
        private List<Car> cars;

        [SetUp]
        public void setup()
        {
            CarRepository = new Mock<Repository>();
            //setup the mock
            cars = new List<Car>
            {
              new Car(){id="1", Brand="Mercedes-Benz", Fuel="Hybrid", IsEcoFriendly=true},
              new Car(){id="2", Brand="Maruti-Suzuki", Fuel="Hybrid", IsEcoFriendly=true},
              new Car(){id="3", Brand="Alto", Fuel="Hybrid", IsEcoFriendly=false},
            };
        }
        [Test]
        public void TestEcofriendlyCars()
        {
      

            //Arrange
            var CarBL = new BusinessLogicTest(CarRepository.Object);
            var Carlist = CarBL.GetEcofriendlyCars();

            //Assert
            Assert.IsTrue(Carlist.Count == 2);
            Assert.IsTrue(Carlist.All(s => s.IsEcoFriendly==true));
        }
    }
}
