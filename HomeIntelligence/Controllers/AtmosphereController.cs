using System;
using System.Threading.Tasks;
using HomeIntelligence.Commands;
using HomeIntelligence.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeIntelligence.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtmosphereController : Controller
    {
        private readonly IMediator _mediator;
        
        public AtmosphereController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] DateTime? filterDate, Guid? location = null, Guid? sensor = null)
        {
            var query = new GetAtmosphereQuery()
            {
                FilterDate = filterDate,
                Location = location,
                Sensor = sensor,
            };

            var results = await _mediator.Send(query);

            return Ok(results);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SaveAtmosphereCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("Post", result);
        }

        // GET: Atmosphere
        [HttpGet("Temperature")]
        public async Task<ActionResult> GetTemperature([FromQuery] DateTime? filterDate, [FromQuery] Guid? location = null)
        {
            var query = new GetTemperatureQuery()
            {
                FilterDate = filterDate, 
                Location = location,
            };

            var results = await _mediator.Send(query);

            return Ok(results);
        }

        [HttpPost("Temperature")]
        public async Task<ActionResult> Post([FromBody] SaveTemperatureCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("Post", result);
        }

    }
}