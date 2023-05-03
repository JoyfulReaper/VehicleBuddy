using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleBuddy.Shared.Contracts.Make;
using VehicleBuddy.Shared.Contracts.Model;
using VehicleBuddy.Shared.Contracts.Package;

namespace VehicleBuddy.Shared.Contracts.Vehicle;

public class VehicleResponse
{
    public int VehicleId { get; set; }

    public MakeResponse Make { get; set; } = default!;

    public ModelResponse Model { get; set; } = default!;

    public PackageResponse Package { get; set; } = default!;

    [MaxLength(20)]
    public string VIN { get; set; } = default!;

    public int Year { get; set; }

    public bool IsAutomatic { get; set; }

    [MaxLength(50)]
    public string Color { get; set; } = default!;

    public DateTime DateAcquired { get; set; }

    public DateTime? DateSold { get; set; }

    public int? Mileage { get; set; }
}
