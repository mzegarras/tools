using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;


using CustomerApi.Data;
namespace CustomerApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

            private readonly IDistributedCache _distributedCache;
    public CustomersController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var dbConnection = DBConnection.Instance();
            dbConnection.IsConnect();

            return new string[] { "value2", "value3" };
        }

        private static readonly String KEY_CACHE="customer:{0}";

          // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
             System.Console.WriteLine("GET");
            System.Console.WriteLine(String.Format(KEY_CACHE,id),id);
            System.Console.WriteLine("********");

            var valueFromRedis = _distributedCache.GetString(String.Format(KEY_CACHE,id));

            return valueFromRedis;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Random rnd = new Random();
            int id  = rnd.Next(1, 100);

            System.Console.WriteLine("POST");
            System.Console.WriteLine(String.Format( KEY_CACHE,id),id);
            System.Console.WriteLine("********");
            _distributedCache.SetString(String.Format(KEY_CACHE,id), value);

            var messageUtil = MessageUtil.Instance();
            messageUtil.IsConnect();
            messageUtil.sendMessage(String.Format("Customer:Created: {0}",id));
            messageUtil.Close();
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            System.Console.WriteLine("PUT");
            System.Console.WriteLine(String.Format(KEY_CACHE,id),id);
            System.Console.WriteLine("********");
            _distributedCache.SetString(String.Format(KEY_CACHE,id), value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            System.Console.WriteLine("DELETE");
            System.Console.WriteLine(String.Format(KEY_CACHE,id),id);
            System.Console.WriteLine("********");
            _distributedCache.Remove(String.Format(KEY_CACHE,id));

            var messageUtil = MessageUtil.Instance();
            messageUtil.IsConnect();
            messageUtil.sendMessage(String.Format("Customer:Created: {0}",id));
            messageUtil.Close();
        }


    }
}