using Microsoft.AspNetCore.Mvc;
using MQHomeWork.DB;
using System.Net;

namespace MQHomeWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IPController : ControllerBase
    {

        private readonly ILogger<IPController> _logger;

        Repository _repository;
        public IPController(ILogger<IPController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<Location> Location(string ip)
        {
            if (!string.IsNullOrEmpty(ip) && IPAddress.TryParse(ip, out IPAddress? IPaddress) && IPaddress != null)
            {
                return _repository.GetLocation(IPaddress);
            }
            else
            {
                return NotFound();
            }
        }
    }
}