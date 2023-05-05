using VehicleBuddy.Server.Models;

namespace VehicleBuddy.Server.Repositories.Interfaces
{
    public interface IMakeRepository
    {
        Task<IList<Make>> GetAllAsync();
        Task<Make?> GetAsync(int makeId);
        Task SaveAsync(Make make);
    }
}