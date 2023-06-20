using VehicleBuddy.Server.Models;

namespace VehicleBuddy.Server.Repositories.Interfaces
{
    public interface IFuelTypeRepository
    {
        Task DeleteAsync(int fuelTypeId);
        Task<List<FuelType>> GetAllAsync();
        Task<FuelType> GetAsync(int fuelTypeId);
        Task SaveAsync(FuelType fuelType);
    }
}