using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coding.Challenge.Firstname.Lastname;

namespace Coding.Challenge.Firstname.Lastname
{
    [ApiController]
    [Route("[Controller]")]
    public class CodeChallengeController : ControllerBase
    {
          
        private readonly Irepository _Repository = null;

        public CodeChallengeController(Irepository Repository)
        {
            _Repository = Repository;
        }
   
        [HttpGet]
        [Route("{id}")]
        public ContentResult Index(string id)
        {
            Car data = _Repository.FetchHTMLDoc(id);
                 
            return base.Content("&lt;!DOCTYPe html&gt;&#13;" +
                "&lt;html&gt;" + "&#10" +
                "&lt;head&gt;" + "\n" +
                "&lt;title &gt;" + data.Brand + " &lt;/title&gt;" + "\n" +
                "&lt;/head &gt;" + "\n" +
                "&lt;body &gt;" + "\n" +
                "&lt; h1 title=" + data.Brand + "&gt;" + data.Brand + "&lt;/h1&gt;" +"\n" +
                "&lt;h2 title = " + data.Brand + "&gt; Fuel Type:" + data.Fuel + "&lt;/h2&gt;"+ "\n" +
                "&lt;div &gt; Model:" + data.id + "&lt;/div&gt;" +"\n" +
                "&lt;/body&gt;" + "\n" +
                "&lt;/html&gt;"+ "\n","text/html");
        }

        
    }
}
