using System.ComponentModel.DataAnnotations;

namespace VehicleBuddy.Shared.Contracts.Model;
public class ModelResponse
{
    [Key]
    public int ModelId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = default!;
}
