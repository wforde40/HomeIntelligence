using HomeIntelligence.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeIntelligence.Commands
{
    public class SaveAtmosphereCommand : IRequest<Atmosphere>
    {
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public double? Pressure { get; set; }
        public Guid? Location { get; set; }
        public Guid? Sensor { get; set; }
    }
}
