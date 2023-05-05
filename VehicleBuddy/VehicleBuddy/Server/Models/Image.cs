namespace VehicleBuddy.Server.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int? VehicleId { get; set; }
        public string ImageName { get; set; } = default!;
        public string ImagePath { get; set; } = default!;
        public string OriginalFileName { get; set; } = default!;

    }
}
