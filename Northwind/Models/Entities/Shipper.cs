﻿namespace Northwind.Models.Entities;

public class Shipper
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; }

    public string Phone { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
