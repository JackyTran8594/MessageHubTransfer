using MessageHubTransfer.Hubs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageHubTransfer.Controllers
{
    [Route("api/serverInfo")]
    [ApiController]
    public class ServerInfoController : ControllerBase
    {

        private readonly ILogger<MessageBrokerHub> _logger;

        public ServerInfoController(ILogger<MessageBrokerHub> logger)
        {
            _logger = logger;
        }

        // GET: api/v1/serverInfo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("===== serverInfo ======" + DateTime.Now);
            return new string[] { "value1", "value2" };
        }

        // GET api/v1/serverInfo/5
        [HttpGet("checkStorage/{path}")]
        public string Get(string path)
        {
            return "value";
        }

        // POST api/v1/serverInfo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/v1/serverInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/v1/serverInfo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
