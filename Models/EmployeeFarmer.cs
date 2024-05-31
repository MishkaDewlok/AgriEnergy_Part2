using System;
using System.Collections.Generic;

namespace AgriEnergy.Models;

public partial class EmployeeFarmer
{
    public int Farmers { get; set; }

    public int? EmployeeId { get; set; }

    public int? FarmerId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Farmer? Farmer { get; set; }
}
