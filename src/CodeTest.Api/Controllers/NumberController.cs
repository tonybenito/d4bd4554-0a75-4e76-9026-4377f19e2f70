using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NumberSeries;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberController : ControllerBase
    {

        private readonly ILogger<NumberController> _logger;
        private readonly INumberService _numberService;

        public NumberController(ILogger<NumberController> logger, INumberService numberService)
        {
            _logger = logger;
            _numberService = numberService;
        }

        [HttpGet]
        public string Get()
        {
            string series = _numberService.GetBiggestSeries("6 2 4 3 1 5 9");
            return series;

        }
    }
}
