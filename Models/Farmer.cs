using System;
using System.Collections.Generic;

namespace AgriEnergy.Models;

public partial class Farmer
{
    public Farmer()
    {
        EmployeeFarmers = new HashSet<EmployeeFarmer>();
        Products = new HashSet<Product>();
    }

    public int FarmerId { get; set; }

    public string FarmerUserName { get; set; } = null!;

    public string FarmerPassword { get; set; } = null!;

    public virtual ICollection<EmployeeFarmer> EmployeeFarmers { get; set; } = new List<EmployeeFarmer>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
