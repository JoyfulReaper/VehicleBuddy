using VehicleBuddy.Server.Models;

namespace VehicleBuddy.Server.Repositories.Interfaces
{
    public interface IModelRepository
    {
        Task<IList<Model>> GetAllAsync();
        Task<Model?> GetAsync(int modelId);
        Task SaveAsync(Model model);
    }
}