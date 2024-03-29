﻿using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Challenge.Firstname.Lastname
{
    public class CarRepository : ICarRepository
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
                   
                    if(nNode.OriginalName== "h1")
                    {
                        string value = Checkcondition(nNode, cars);
                        cars.Brand = value;
                    }
                    if (nNode.OriginalName == "h2")
                    {
                        string value = Checkcondition(nNode, cars);
                        cars.Fuel = value;
                    }
                    else if(nNode.OriginalName=="div")
                    {                       
                        List<string> list = GetModels();
                        cars.Models = list;
                        //Console.WriteLine(Models.Count());
                    }
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
                 
                //foreach (Car car in Getcars())
                //{
                //    ArrayList arraylist = new ArrayList();
                //    arraylist.Add(car.id);
                //    return arraylist.ToString();               
                //}
                         
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

        public List<string> GetModels()
        {
            List<string> Models = new List<string>();
            foreach (Car car in Getcars())
            {
              
                Models.Add(car.id);
            }
            return Models;
        }

        public string GetCarBrandbyId(string Id)
        {
            Car cars = Getcars().Where(x => x.id == Id).FirstOrDefault();
            return cars.Brand;
        }
    }
}
    

