using System.Data;

namespace VehicleBuddy.Server.Data.Interfaces;
public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}