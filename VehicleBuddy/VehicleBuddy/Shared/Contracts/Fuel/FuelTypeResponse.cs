using System.ComponentModel.DataAnnotations;

namespace VehicleBuddy.Shared.Contracts.Fuel;

public class FuelTypeResponse
{
    public int FuelTypeId { get; set; }

    [MaxLength(50)]
    public string Type { get; set; } = default!;
}
