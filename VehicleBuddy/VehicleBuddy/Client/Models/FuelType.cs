using System.ComponentModel.DataAnnotations;

namespace VehicleBuddy.Client.Models;

public class FuelType
{
    [Key]
    public int FuelTypeId { get; set; }
    [MaxLength(50)]
    public string Type { get; set; } = default!;
}
