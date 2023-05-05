using Dapper;
using System.Data;
using VehicleBuddy.Server.Data.Interfaces;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Server.Repositories.Interfaces;

namespace VehicleBuddy.Server.Repositories;

public class MakeRepository : IMakeRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public MakeRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<Make?> GetAsync(int makeId)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QuerySingleOrDefaultAsync<Make>("spMake_GetById", new { MakeId = makeId }, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task SaveAsync(Make make)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var id = await connection.QuerySingleAsync<Make>("spMake_Upsert", make, commandType: CommandType.StoredProcedure);
    }

    public async Task<IList<Make>> GetAllAsync()
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<Make>("spMake_GetAll", commandType: CommandType.StoredProcedure);
        return result.AsList();
    }

}
