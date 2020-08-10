using ActionHiding.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RouteHidingTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RouteHiding]
    public class DemoController : ControllerBase
    {
      

        private readonly ILogger<WeatherForecastController> _logger;

        public DemoController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello-world")]
        public string HelloWord()
        {
            return "hello world";
        }

        [HttpGet("Hah")]
        public string Hah()
        {
            return "Hah";
        }
    }
}
