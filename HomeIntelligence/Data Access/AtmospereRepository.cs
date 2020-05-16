using HomeIntelligence.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using HomeIntelligence.Queries;

namespace HomeIntelligence.Data_Access
{
    public class AtmospereRepository : IAtmosphereRepository
    {
        private readonly ConnectionConfig _connections;

        private SqlConnection Connection => new SqlConnection(_connections.HomeIntelligence);

        public AtmospereRepository(ConnectionConfig connections) =>
            (_connections) = (connections);
        
        public async Task<IEnumerable<Temperature>> GetLatestTemperature(GetTemperatureQuery query)
        {
            using(var conn = Connection)
            {
                var select = $"Select ID, Temperature Value, DateRecieved, Location from Atmosphere";

                var where = "";
                where = query.Location is null ? where : where + "and Location = @Location ";
                where = query.FilterDate is null ? where : where + "and DateRecieved >= @FilterDate ";
                where = string.IsNullOrEmpty(where) ? "" : "Where " + where.Substring(4);
                var orderBy = "Order By Id desc";

                var sql = $"{select} {where} {orderBy}";

                var results  = await conn.QueryAsync<Temperature>(sql, query);

                return results;
            }
        }


        public async Task<Temperature> SaveTemperature(Temperature temperature)
        {
            using(var conn = Connection)
            {
                var sql = @"Insert Into Atmosphere (Value, DateRecieved, Location)
                            Output Inserted.* 
                            Values (@Value, @DateRecieved, @Location)";

                return await conn.QueryFirstAsync<Temperature>(sql, temperature);
            }
        }

        public async Task<IEnumerable<Atmosphere>> GetAtmosphere(GetAtmosphereQuery query)
        {
            using(var conn = Connection)
            {
                var select = $"Select * from Atmosphere";

                var where = "";
                where = query.Location is null ? where : where + "and Location = @Location ";
                where = query.Location is null ? where : where + "and Sensor = @Sensor ";
                where = query.FilterDate is null ? where : where + "and DateRecieved >= @FilterDate ";
                where = string.IsNullOrEmpty(where) ? "" : "Where " + where.Substring(4);
                var orderBy = "Order By Id desc";

                var sql = $"{select} {where} {orderBy}";

                return await conn.QueryAsync<Atmosphere>(sql, query);
            }
        }

        public async Task<Atmosphere> SaveAtmosphere(Atmosphere atmosphere)
        {
            using(var connection = Connection)
            {
                var sql = @"Insert Into Atmosphere (temperature, humidity, pressure, location, sensor)
                            Output Inserted.*
                            Values (@Temperature, @Humidity, @Pressure, @Location, @Sensor)";

                return await connection.QueryFirstOrDefaultAsync<Atmosphere>(sql, atmosphere);
            }
        }
    }
}
