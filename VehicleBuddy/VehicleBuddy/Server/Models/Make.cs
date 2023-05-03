using System.ComponentModel.DataAnnotations;

namespace VehicleBuddy.Server.Models;

public class Make
{
    [Key]
    public int MakeId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [MaxLength(50)]
    public string Country { get; set; } = default!;

    [MaxLength(20)]
    [Phone]
    public string CustomerSupportPhoneNumber { get; set; } = default!;

    [MaxLength(150)]
    [EmailAddress]
    public string CustomerSupportEmailAddress { get; set; } = default!;

}
