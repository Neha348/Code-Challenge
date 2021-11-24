using System;
using System.Collections.Generic;
using System.Text;


namespace Coding.Challenge.Firstname.Lastname
{

    public class Car
    {
        public string id { get; set; }
        public string Brand { get; set; } 

        public bool IsEcoFriendly { get; set; }
        public string Fuel { get; set; }

        public List<string> Models { get; set; } 
       
        public static Car Lookup(string id)
         {
            Car car = new Car();
            car.id = id;
            return car;
        }
    }
}
