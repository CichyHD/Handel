using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Handel.DataAccess.Contract.Services;

namespace Handel.MVC.Controllers
{
    public class ExampleApiController:BaseApiController
    {
        private readonly IFloatTestService _floatTestService;

        public ExampleApiController(IFloatTestService floatTestService)
        {
            _floatTestService = floatTestService;
        }

        [HttpGet]
        public IHttpActionResult DoSomethingInLastLayer(string question)
        {
            string answer = _floatTestService.DoSomeRandomShit(question);
            if (!String.IsNullOrEmpty(answer))
            {
                if (answer == "I've done some random shit to test this float")
                {
                    return Ok(answer);
                }
                
            }
            return BadRequest("404 is coming");
        }
    }
}