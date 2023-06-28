using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleBuddy.Shared.Contracts.Fuel
{
    public class UpdateFuelTypeRequest
    {

        public int FuelTypeId { get; set; }

        [MaxLength(50)]
        public string Type { get; set; } = default!;
    }
}
