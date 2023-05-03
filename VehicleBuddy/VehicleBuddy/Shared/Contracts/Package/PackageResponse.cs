using VehicleBuddy.Shared.Contracts.Fuel;

namespace VehicleBuddy.Shared.Contracts.Package;

public class PackageResponse
{
    public int PackageId { get; set; }

    public FuelTypeResponse FuelType { get; set; } = default!;

    public bool Is4WD { get; set; }

    public bool IsHatchBack { get; set; }

    public int NumberOfPassengers { get; set; }

    public int NumberOfDoors { get; set; }

    public int NumberOfCylinders { get; set; }

    public DateTime StartYear { get; set; }

    public DateTime? EndYear { get; set; }
}
