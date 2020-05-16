using HomeIntelligence.Data_Access;
using HomeIntelligence.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeIntelligence.Queries
{
    public class GetAtmosphereQueryHandler : IRequestHandler<GetAtmosphereQuery, IEnumerable<Atmosphere>>
    {
        private readonly IAtmosphereRepository _repository;

        public GetAtmosphereQueryHandler(IAtmosphereRepository repository) =>
            (_repository) = (repository);

        public async Task<IEnumerable<Atmosphere>> Handle(GetAtmosphereQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAtmosphere(request);
        }
    }
}
