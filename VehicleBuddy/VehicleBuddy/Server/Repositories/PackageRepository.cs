using System.Data;
using Dapper;
using VehicleBuddy.Server.Data.Interfaces;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Server.Repositories.Interfaces;

namespace VehicleBuddy.Server.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public PackageRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<Package?> GetAsync(int packageId)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<Package, FuelType, Package>(
            "spPackage_GetById",
            (p, f) =>
            {
                p.FuelType = f;
                return p;
            },
            new { PackageId = packageId }, commandType: CommandType.StoredProcedure);
        return result.SingleOrDefault();
    }

    public async Task<IList<Package>> GetAllAsync()
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var allPackages = await connection.QueryAsync<Package, FuelType, Package>(
            "spPackage_GetAll",
            (p, f) =>
            {
                p.FuelType = f;
                return p;
            },
            splitOn: "FuelId", commandType: CommandType.StoredProcedure);
        return allPackages.AsList();
    }

    public async Task SaveAsync(Package package)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var id = await connection.QuerySingleAsync<int>("spPackage_Upsert", package, commandType: CommandType.StoredProcedure);
    }

}
