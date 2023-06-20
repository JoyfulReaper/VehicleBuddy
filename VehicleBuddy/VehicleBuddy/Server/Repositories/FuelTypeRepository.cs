using Dapper;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using VehicleBuddy.Server.Data.Interfaces;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Server.Repositories.Interfaces;

namespace VehicleBuddy.Server.Repositories.Interfaces
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public FuelTypeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<FuelType>> GetAllAsync()
        {
            using IDbConnection connection = _dbConnectionFactory.CreateConnection();
            List<FuelType> fuelTypes = (await connection.QueryAsync<FuelType>("spFuelType_GetAll", commandType: CommandType.StoredProcedure)).ToList();

            return fuelTypes;
        }

        public async Task<FuelType> GetAsync(int fuelTypeId)
        {
            using IDbConnection connection = _dbConnectionFactory.CreateConnection();

            FuelType fuelType = await connection.QuerySingleAsync<FuelType>("spFuelType_Get", fuelTypeId, commandType: CommandType.StoredProcedure);
            return fuelType;
        }

        public async Task SaveAsync(FuelType fuelType)
        {
            using IDbConnection connection = _dbConnectionFactory.CreateConnection();

            var id = await connection.QuerySingleAsync<int>("spFuelType_Upsert", fuelType, commandType: CommandType.StoredProcedure);
            fuelType.FuelTypeId = id;

        }

        public async Task DeleteAsync(int fuelTypeId)
        {
            using IDbConnection connection = _dbConnectionFactory.CreateConnection();
            await connection.ExecuteAsync("spFuelType_Delete", fuelTypeId, commandType: CommandType.StoredProcedure);
        }
    }
}
