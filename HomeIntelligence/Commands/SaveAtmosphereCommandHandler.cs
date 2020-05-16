using HomeIntelligence.Data_Access;
using HomeIntelligence.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeIntelligence.Commands
{
    public class SaveAtmosphereCommandHandler : IRequestHandler<SaveAtmosphereCommand, Atmosphere>
    {
        private readonly IAtmosphereRepository _repository;

        public SaveAtmosphereCommandHandler(IAtmosphereRepository repository) =>
            (_repository) = (repository);
        public async Task<Atmosphere> Handle(SaveAtmosphereCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request");

            if(request.Temperature is null && 
                request.Humidity is null && 
                request.Pressure is null)
            {
                // Must have at least one measurement per record
                throw new ArgumentNullException("Measurements", "One of the measurement properties must be populated.");
            }

            var atmosphere = new Atmosphere()
            {
                Temperature = request.Temperature ??= 0,
                Humidity = request.Humidity ??= 0,
                Pressure = request.Pressure ??= 0,
                Location = request.Location ??= Guid.Empty,
                Sensor = request.Sensor ??= Guid.Empty
            };
            
                 
            return await _repository.SaveAtmosphere(atmosphere);
        }
    }
}
