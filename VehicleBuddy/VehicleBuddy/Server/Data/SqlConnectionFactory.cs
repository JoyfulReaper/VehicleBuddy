using Microsoft.Data.SqlClient;
using System.Data;
using VehicleBuddy.Server.Data.Interfaces;

namespace VehicleBuddy.Server.Data;

public class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _config;

    public SqlConnectionFactory(IConfiguration config)
    {
        _config = config;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _config.GetConnectionString("VehicleBuddy");
        return new SqlConnection(connectionString);
    }
}
