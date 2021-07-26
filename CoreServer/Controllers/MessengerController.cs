using Messenger;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessengerController : ControllerBase
    {

        static List<Message> ListOfMessages = new List<Message>();

        // GET api/<MessengerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string outputString = "No";

            if (id < ListOfMessages.Count && id >= 0)
                outputString = JsonConvert.SerializeObject(ListOfMessages[id]);
           // Console.WriteLine(String.Format("Message № {0} : {1}", id, outputString));

            return outputString;
        }

        // POST api/<MessengerController>
        [HttpPost]
        public IActionResult Post([FromBody] Message msg)
        {
            if(msg == null)
            {
                return BadRequest();
            }
            ListOfMessages.Add(msg);
            Console.WriteLine(String.Format("Count: {0}, Text : {1}", ListOfMessages.Count, msg));
            return new OkResult();
        }
    }
}
