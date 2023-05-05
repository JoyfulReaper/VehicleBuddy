using Dapper;
using System.Data;
using VehicleBuddy.Server.Data.Interfaces;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Server.Repositories.Interfaces;

namespace VehicleBuddy.Server.Repositories;

public class ModelRepository : IModelRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ModelRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<Model?> GetAsync(int modelId)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QuerySingleOrDefaultAsync<Model>("spModel_GetById", new { ModelId = modelId }, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task SaveAsync(Model model)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var id = await connection.QuerySingleAsync<Model>("spModel_Upsert", model, commandType: CommandType.StoredProcedure);
    }

    public async Task<IList<Model>> GetAllAsync()
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<Model>("spModel_GetAll", commandType: CommandType.StoredProcedure);
        return result.AsList();
    }


}
