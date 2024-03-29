﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Coding.Challenge.Firstname.Lastname;
using Moq;
using System.Net.Http;

namespace Project_TestCases.Test_Methods
{
    class ControllerTest
    {
        private Mock<ICarRepository> CarRepository;
        [Test]
        public void GetReturnCar()
        {
            CarRepository = new Mock<ICarRepository>();
            List<Car> cars= new List<Car>();
            CarRepository.Setup(p => p.GetCarBrandbyId("1")).Returns("Mercedes-Benz");
            CodeChallengeController controller1 = new CodeChallengeController(((ICarRepository)CarRepository.Object));
            string result = controller1.GetCarBrandbyID("1");
            Assert.AreEqual("Mercedes-Benz", result);

        }
    }
}
