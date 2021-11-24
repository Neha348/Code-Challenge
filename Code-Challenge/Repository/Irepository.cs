using Coding.Challenge.Firstname.Lastname;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Coding.Challenge.Firstname.Lastname
{
    public interface Irepository
    {

        public  Car FetchHTMLDoc(string ID);
        public  string GetPropValue(object src, string propName);
        public  string Checkcondition(HtmlNode node, object src);

    }
}
