using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTSR.Domain.Entities;

public class Table
{
    public int Id { get; set; }
    public string TableNumber { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string? QRCodeToken { get; set; }
    public string Status { get; set; } = "Available"; // Available, Occupied, Reserved  

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}