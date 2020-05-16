using HomeIntelligence.Models;
using HomeIntelligence.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeIntelligence.Data_Access
{
    public interface IAtmosphereRepository
    {
        Task<IEnumerable<Atmosphere>> GetAtmosphere(GetAtmosphereQuery query);
        Task<Atmosphere> SaveAtmosphere(Atmosphere atmosphere);
        Task<IEnumerable<Temperature>> GetLatestTemperature(GetTemperatureQuery query);
        Task<Temperature> SaveTemperature(Temperature temperature);
    }
}