using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleBuddy.Shared.Contracts.Vehicle
{
    public class UpdateVehicleRequest
    {
        public int VehicleId { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public int PackageId { get; set; }

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
}
