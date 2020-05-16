using HomeIntelligence.Data_Access;
using HomeIntelligence.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeIntelligence.Commands
{
    public class SaveTemperatureHandler : IRequestHandler<SaveTemperatureCommand, Temperature>
    {

        private readonly IAtmosphereRepository _atmosphereRepository;

        public SaveTemperatureHandler(IAtmosphereRepository atmosphereRepository) =>
            (_atmosphereRepository) = (atmosphereRepository);

        public async Task<Temperature> Handle(SaveTemperatureCommand request, CancellationToken cancellationToken)
        {
            var temp = new Temperature()
            {
                Value = request.Value,
                DateRecieved = DateTime.Now,
                Location = request.Location,
            };

            return await _atmosphereRepository.SaveTemperature(temp);
        }
    }
}
