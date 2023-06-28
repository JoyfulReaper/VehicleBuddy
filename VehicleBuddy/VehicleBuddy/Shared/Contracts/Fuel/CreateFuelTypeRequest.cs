using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleBuddy.Shared.Contracts.Fuel
{
    public class CreateFuelTypeRequest
    {

        [MaxLength(50)]
        public string Type { get; set; } = default!;
    }
}
