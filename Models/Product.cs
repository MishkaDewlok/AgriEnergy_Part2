using System;
using System.Collections.Generic;

namespace AgriEnergy.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public decimal ProductPrice { get; set; }

    public int ProductQuantity { get; set; }

    public string ProductCategory { get; set; } = null!;

    public DateTime ProductionDate { get; set; }

    public int? FarmerId { get; set; }

    public virtual Farmer? Farmer { get; set; }

}
