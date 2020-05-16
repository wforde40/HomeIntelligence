using HomeIntelligence.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeIntelligence.Commands
{
    public class SaveTemperatureCommand : IRequest<Temperature>
    {
        public double Value { get; set; }
        public Guid Location { get; set; }

    }
}
