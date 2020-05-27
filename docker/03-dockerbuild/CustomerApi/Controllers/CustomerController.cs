using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            string getEnv = Environment.GetEnvironmentVariable("CUSTOMER_NAME");


            return new string[] { "value2", "value3",getEnv };
        }

    }
}