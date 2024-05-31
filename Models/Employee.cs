using System;
using System.Collections.Generic;

namespace AgriEnergy.Models;

public partial class Employee
{
    public Employee()
    {
        EmployeeFarmers = new HashSet<EmployeeFarmer>();
    }

    public int EmployeeId { get; set; }

    public string EmployeeUserName { get; set; } = null!;

    public string EmployeePassword { get; set; } = null!;

    public virtual ICollection<EmployeeFarmer> EmployeeFarmers { get; set; } = new List<EmployeeFarmer>();
}
