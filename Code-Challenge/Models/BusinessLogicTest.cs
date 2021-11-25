using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Challenge.Firstname.Lastname
{
    public class BusinessLogicTest
    {

        private readonly Repository _Repository = null;

        public BusinessLogicTest(Repository Repository)
        {
            _Repository = Repository;
        }

        public List<Car> GetEcofriendlyCars()
        {
            var result = new List<Car>();
            result = Repository.Getcars().Where(x => x.IsEcoFriendly == true).ToList();
            return result; 
        }
    }
}
