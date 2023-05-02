using System.ComponentModel.DataAnnotations;

namespace VehicleBuddy.Client.Models;

public class Model
{
    [Key]
    public int ModelId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = default!;
}
