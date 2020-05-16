using HomeIntelligence.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeIntelligence.Queries
{
    public class GetAtmosphereQuery : IRequest<IEnumerable<Atmosphere>>
    {
        public DateTime? FilterDate { get; set; }
        public Guid? Location { get; set; }
        public Guid? Sensor { get; set; }
    }
}
