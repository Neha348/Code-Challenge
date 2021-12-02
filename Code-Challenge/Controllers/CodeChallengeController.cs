using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coding.Challenge.Firstname.Lastname;
using System.Net.Http;
using System.Net;

namespace Coding.Challenge.Firstname.Lastname
{
    [ApiController]
    [Route("[Controller]")]
    public class CodeChallengeController : ControllerBase
    {
          
        private readonly ICarRepository _Repository = null;

        public CodeChallengeController(ICarRepository Repository)
        {
            _Repository = Repository;
        }
   
        [HttpGet]
        [Route("{id}")]
        public ContentResult Index(string id)
        {
            Car data = _Repository.FetchHTMLDoc(id);
             if(data==null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Id cannot be found", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new System.Web.Http.HttpResponseException(response);
            }
            String div = "";
            foreach (var item in data.Models)
            {
                div += "&lt;div&gt; Model:" + item + "&lt;/div&gt;";
            }
                 
                return base.Content("&lt;!DOCTYPe html&gt;&#13;" +
                "&lt;html&gt;" + "&#10" +
                "&lt;head&gt;" + "\n" +
                "&lt;title &gt;" + data.Brand + " &lt;/title&gt;" + "\n" +
                "&lt;/head &gt;" + "\n" +
                "&lt;body &gt;" + "\n" +
                "&lt; h1 title=" + data.Brand + "&gt;" + data.Brand + "&lt;/h1&gt;" + "\n" +
                "&lt;h2 title = " + data.Brand + "&gt; Fuel Type:" + data.Fuel + "&lt;/h2&gt;" + div +                             
                "&lt;/body&gt;" + "\n" +
                "&lt;/html&gt;"+ "\n","text/html");
        }

        
        public string GetCarBrandbyID( string id)
        {
            return _Repository.GetCarBrandbyId(id);
        }

        
    }
}
