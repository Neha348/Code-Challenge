using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Challenge.Firstname.Lastname
{
    public class BusinessLogicTest
    {

        private readonly CarRepository _Repository = null;

        public BusinessLogicTest(CarRepository Repository)
        {
            _Repository = Repository;
        }

        public List<Car> GetEcofriendlyCars()
        {
            var result = new List<Car>();
            result = CarRepository.Getcars().Where(x => x.IsEcoFriendly == true).ToList();
            return result; 
        }
    }
}
