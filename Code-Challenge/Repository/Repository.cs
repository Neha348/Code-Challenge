using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Challenge.Firstname.Lastname
{
    public class Repository : Irepository
    {
        public static List<Car> Getcars()
        {
            return new List<Car>()
            {
              new Car(){id="1", Brand="Mercedes-Benz", Fuel="Hybrid", IsEcoFriendly=true},
              new Car(){id="2", Brand="Maruti-Suzuki", Fuel="Hybrid", IsEcoFriendly=true},
              new Car(){id="3", Brand="Alto", Fuel="Hybrid", IsEcoFriendly=false},
            };
        }
        public Car FetchHTMLDoc(string ID)
        {
            
            HtmlDocument document2 = new HtmlDocument();
            document2.Load(@"C:\Users\hp\source\repos\Code-Challenge\Code-Challenge\View\Index.cshtml");
            var script = document2.DocumentNode.Descendants()
                                         .Where(n => n.Name == "script")
                                         .First().InnerText;
            Console.WriteLine("discovered script tag:\n" + script);
            Car cars = Getcars().Where(x => x.id == ID).FirstOrDefault();         
            var Headnode = document2.DocumentNode.SelectSingleNode("//head");
            foreach (var nNode in Headnode.Descendants())
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    string value = Checkcondition(nNode, cars);
                    cars.Brand = value;                 
                }

            }

            var Bodynode = document2.DocumentNode.SelectSingleNode("//body");
            foreach (var nNode in Bodynode.Descendants())
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    string value = Checkcondition(nNode, cars);
                    //Console.WriteLine(nNode.Name);
                    //Console.WriteLine(value);
                }
            }
                        
            return cars;


        }
        public string Checkcondition(HtmlNode node, object src)
        {
            if (node.Attributes.Contains("data-cond"))
            {
                string value = GetPropValue(src, node.Attributes.ToList().FirstOrDefault().Value);
                if (value == "True")
                {
                    if (node.InnerHtml.Contains("$"))
                    {
                        string title = GetPropValue(src, node.InnerHtml);
                        return Convert.ToString(title);
                    }
                }

            }

            else if (node.Attributes.Contains("data-repeat-model"))
            {
            //    string propName = node.InnerHtml;
            //    string prop = propName.Remove(0, propName.IndexOf('.') + 1).TrimEnd('}');                
                foreach (Car car in Getcars())
                {
                   List<string> mylist=  new List<string> { car.id, car.Brand, car.Fuel, car.IsEcoFriendly.ToString() };
                    car.Models.Add(mylist.ToString()) ;
                     return Convert.ToString(car.Models.Count());
                    Console.WriteLine(car.Models);
                }
                          

                }
            
            else if (node.InnerHtml.Contains("$"))
            {
                string value = GetPropValue(src, node.InnerHtml);
                return Convert.ToString(value);
            }
            return "noValue";
        }

        public string GetPropValue(object src, string propName)
        {
            string prop = propName.Remove(0, propName.IndexOf('.') + 1).TrimEnd('}');
            return Convert.ToString(src.GetType().GetProperty(prop).GetValue(src, null));
        }

        public string GetCarBrandbyId(string Id)
        {
            Car cars = Getcars().Where(x => x.id == Id).FirstOrDefault();
            return cars.Brand;
        }
    }
}
    

