using HomeIntelligence.Data_Access;
using HomeIntelligence.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeIntelligence.Queries
{
    public class GetTemperatureHandler : IRequestHandler<GetTemperatureQuery, IEnumerable<Temperature>>
    {

        private readonly IAtmosphereRepository _repository;

        public GetTemperatureHandler(IAtmosphereRepository repository) =>
            (_repository) = (repository);

        public async Task<IEnumerable<Temperature>> Handle(GetTemperatureQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetLatestTemperature(request);
            return results;
        }
    }
}
