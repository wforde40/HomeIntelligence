using HomeIntelligence.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace HomeIntelligence.Queries
{
    public class GetTemperatureQuery : IRequest<IEnumerable<Temperature>>
    {
        public DateTime? FilterDate { get; set; }
        public Guid? Location { get; set; }
    }
}
