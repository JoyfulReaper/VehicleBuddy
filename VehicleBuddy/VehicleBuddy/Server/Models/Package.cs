using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleBuddy.Server.Models;

public class Package
{
    [Key]
    public int PackageId { get; set; }

    [ForeignKey("FuelTypeId")]
    public int FuelTypeId { get; set; }

    public bool is4WD { get; set; }

    public bool isHatchBack { get; set; }

    public int NumberOfPassengers { get; set; }

    public int NumberOfDoors { get; set; }

    public int NumberOfCylinders { get; set; }

    public DateTime StartYear { get; set; }

    public DateTime? EndYear { get; set; }

    ////////////
    
    public FuelType? FuelType { get; set; }
}
