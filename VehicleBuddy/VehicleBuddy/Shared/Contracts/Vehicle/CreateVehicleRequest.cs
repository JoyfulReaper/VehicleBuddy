using System.ComponentModel.DataAnnotations;

namespace VehicleBuddy.Shared.Contracts.Vehicle;

public class CreateVehicleRequest
{
    public int MakeId { get; set; }

    public int ModelId { get; set; }

    public int PackageId { get; set; }

    [MaxLength(20)]
    [Required]
    public string VIN { get; set; } = default!;

    [Required]
    public int Year { get; set; }

    [Required]
    public bool IsAutomatic { get; set; }

    [MaxLength(50)]
    [Required]
    public string Color { get; set; } = default!;

    [Required]
    public DateTime DateAcquired { get; set; }

    public int? Mileage { get; set; }
}
