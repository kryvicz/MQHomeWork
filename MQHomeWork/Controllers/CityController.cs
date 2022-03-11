using Microsoft.AspNetCore.Mvc;
using MQHomeWork.DB;

namespace MQHomeWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {

        private readonly ILogger<CityController> _logger;

        Repository _repository;
        public CityController(ILogger<CityController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<Location>> Locations(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                return _repository.GetLocations(city).ToArray();
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}