using VehicleBuddy.Server.Models;

namespace VehicleBuddy.Server.Repositories.Interfaces
{
    public interface IPackageRepository
    {
        Task<IList<Package>> GetAllAsync();
        Task<Package?> GetAsync(int packageId);
        Task SaveAsync(Package package);
    }
}