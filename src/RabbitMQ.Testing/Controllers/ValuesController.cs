using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Factory;

namespace RabbitMQ.Testing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IRabbitMQContext _context;

        public ValuesController(ILogger<ValuesController> logger, MyRabbitMQContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public string Get()
        {
            _context.Channel
                .BasicPublish("", "hello", false, null, Encoding.UTF8.GetBytes("rabbitmq"));
            return "success";
        }
    }
}
